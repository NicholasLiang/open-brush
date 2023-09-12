﻿using System;
using System.IO;
using MoonSharp.Interpreter;
using UnityEngine;

namespace TiltBrush
{
    [LuaDocsDescription("A reference image widget")]
    [MoonSharpUserData]
    public class ImageApiWrapper
    {
        public ImageWidget _ImageWidget;

        public ImageApiWrapper(ImageWidget widget)
        {
            _ImageWidget = widget;
        }

        [LuaDocsDescription("The index of the active widget")]
        public int index => WidgetManager.m_Instance.GetActiveWidgetIndex(_ImageWidget);

        [LuaDocsDescription("Returns a string representation of the image widget")]
        [LuaDocsReturnValue("The string representation of the image widget")]
        public override string ToString()
        {
            return $"Image({_ImageWidget})";
        }

        [LuaDocsDescription("The layer the image is on")]
        public LayerApiWrapper layer
        {
            get => _ImageWidget != null ? new LayerApiWrapper(_ImageWidget.Canvas) : null;
            set => _ImageWidget.SetCanvas(value._CanvasScript);
        }

        [LuaDocsDescription("The group this image is part of")]
        public GroupApiWrapper group
        {
            get => _ImageWidget != null ? new GroupApiWrapper(_ImageWidget.Group, layer._CanvasScript) : null;
            set => _ImageWidget.Group = value._Group;
        }

        [LuaDocsDescription("The transform of the image widget")]
        public TrTransform transform
        {
            get => App.Scene.MainCanvas.AsCanvas[_ImageWidget.transform];
            set
            {
                value = App.Scene.Pose * value;
                App.Scene.ActiveCanvas.AsCanvas[_ImageWidget.transform] = value;
            }
        }

        [LuaDocsDescription("The 3D position of the Image Widget")]
        public Vector3 position
        {
            get => transform.translation;
            set => transform = TrTransform.TRS(value, transform.rotation, transform.scale);
        }

        [LuaDocsDescription("The 3D orientation of the Image Widget")]
        public Quaternion rotation
        {
            get => transform.rotation;
            set => transform = TrTransform.TRS(transform.translation, value, transform.scale);
        }

        [LuaDocsDescription("The scale of the image widget")]
        public float scale
        {
            get => transform.scale;
            set => transform = TrTransform.TRS(transform.translation, transform.rotation, value);
        }

        [LuaDocsDescription("Imports an image widget based on the specified location")]
        [LuaDocsExample(@"Image:Import(""test.png"")")]
        [LuaDocsParameter("location", "The location of the image")]
        [LuaDocsReturnValue("The imported image widget")]
        public static ImageApiWrapper Import(string location) => new (ApiMethods.ImportImage(location));

        [LuaDocsDescription("Selects the image widget")]
        [LuaDocsExample(@"myImage:Select()")]
        public void Select() => ApiMethods.SelectWidget(_ImageWidget);

        [LuaDocsDescription("Removes the image from the current selection")]
        [LuaDocsExample("myImage:Deselect()")]
        public void Deselect() => ApiMethods.DeselectWidget(_ImageWidget);

        [LuaDocsDescription("Deletes the image widget")]
        [LuaDocsExample(@"myImage:Delete()")]
        public void Delete() => ApiMethods.DeleteWidget(_ImageWidget);

        [LuaDocsDescription("Extrudes the image widget with the specified depth and color")]
        [LuaDocsExample(@"Image:Extrude(5, Color.green)")]
        [LuaDocsParameter("depth", "The depth of the extrusion")]
        [LuaDocsParameter("color", "The color of the extrusion")]
        public void Extrude(float depth, ColorApiWrapper color = null)
        {
            var extruder = _ImageWidget.GetComponent<SpriteExtruder>();
            if (depth <= 0)
            {
                extruder.Clear();
            }
            else
            {
                color ??= new ColorApiWrapper(Color.gray);
                extruder.extrudeColor = color._Color;
                extruder.backDistance = depth;
                extruder.Generate();
            }
        }

        [LuaDocsDescription("Encodes the image as a form")]
        [LuaDocsExample(@"formdata = myImage:FormEncode()")]
        [LuaDocsReturnValue("The encoded image so it can be submitted as a response to a HTML form")]
        public string FormEncode() => Convert.ToBase64String(File.ReadAllBytes(_ImageWidget.ReferenceImage.FileFullPath));

        [LuaDocsDescription("Saves an image as a png based on base64 data")]
        [LuaDocsExample(@"Image:SaveBase64(someData, ""image.png"")")]
        [LuaDocsParameter("base64", "The base64 data for the image")]
        [LuaDocsParameter("filename", "The filename to save as")]
        public string SaveBase64(string base64, string filename) => ApiMethods.SaveBase64(base64, filename);
    }
}
