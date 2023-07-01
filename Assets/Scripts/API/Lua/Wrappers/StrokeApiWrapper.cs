﻿using System.Collections.Generic;
using System.Linq;
using MoonSharp.Interpreter;
using UnityEngine;

namespace TiltBrush
{
    [LuaDocsDescription("A specific brush stroke")]
    [MoonSharpUserData]
    public class StrokeApiWrapper
    {
        public Stroke _Stroke;

        private PathApiWrapper m_Path;

        [LuaDocsDescription("Gets or sets the control points of this stroke from a Path")]
        public PathApiWrapper path
        {
            get
            {
                if (_Stroke == null) return new PathApiWrapper();
                if (m_Path == null)
                {
                    int count = _Stroke.m_ControlPoints.Count();
                    var path = new List<TrTransform>(count);
                    for (int i = 0; i < count; i++)
                    {
                        var cp = _Stroke.m_ControlPoints[i];
                        var tr = TrTransform.TR(cp.m_Pos, cp.m_Orient);
                        path.Add(tr);
                    }
                    m_Path = new PathApiWrapper(path);
                }
                return m_Path;
            }
            set
            {
                var startTime = _Stroke.m_ControlPoints[0].m_TimestampMs;
                var endTime = _Stroke.m_ControlPoints[^1].m_TimestampMs;
                _Stroke.m_ControlPoints = new PointerManager.ControlPoint[value._Path.Count];
                for (var i = 0; i < value._Path.Count; i++)
                {
                    var tr = value[i]._TrTransform;
                    _Stroke.m_ControlPoints[i] = new PointerManager.ControlPoint
                    {
                        m_Pos = tr.translation,
                        m_Orient = tr.rotation,
                        m_Pressure = tr.scale,
                        m_TimestampMs = (uint)Mathf.RoundToInt(Mathf.Lerp(startTime, endTime, i))
                    };
                }
                _Stroke.Recreate();
            }
        }

        [LuaDocsDescription("Gets or sets the stroke's brush type")]
        public string brushType
        {
            get => _Stroke?.m_BatchSubset.m_ParentBatch.Brush.Description;
            set
            {
                _Stroke.m_BrushGuid = ApiMethods.LookupBrushDescriptor(value).m_Guid;
                _Stroke.Recreate();
            }
        }

        [LuaDocsDescription("Gets or sets the stroke's size")]
        public float brushSize
        {
            get => _Stroke.m_BrushSize;
            set
            {
                _Stroke.m_BrushSize = value;
                _Stroke.Recreate();
            }
        }

        [LuaDocsDescription("Gets or sets the stroke's Color")]
        public ColorApiWrapper brushColor
        {
            get => new ColorApiWrapper(_Stroke.m_Color);
            set
            {
                _Stroke.m_Color = value._Color;
                _Stroke.Recreate();
            }
        }

        [LuaDocsDescription("Gets or sets the layer the stroke is on")]
        public LayerApiWrapper layer
        {
            get => _Stroke != null ? new LayerApiWrapper(_Stroke.Canvas) : null;
            set
            {
                _Stroke.SetParentKeepWorldPosition(value._CanvasScript);
            }
        }

        public StrokeApiWrapper(Stroke stroke)
        {
            _Stroke = stroke;
        }

        public override string ToString()
        {
            return _Stroke == null ? "Empty Stroke" : $"{brushType} stroke on {layer._CanvasScript.name})";
        }

        // Highly experimental
        [LuaDocsDescription("Assigns the material from another brush type to this stroke (Experimental. Results are unpredictable and are not saved with the scene)")]
        [LuaDocsExample(@"myStroke.ChangeMaterial(""Light"")")]
        [LuaDocsParameter("brushName", "The name (or guid) of the brush to get the material from")]
        public void ChangeMaterial(string brushName)
        {
            var brush = ApiMethods.LookupBrushDescriptor(brushName);
            _Stroke.m_BatchSubset.m_ParentBatch.ReplaceMaterial(brush.Material);
        }

        public TrTransform this[int index]
        {
            get => path._Path[index];
            set
            {
                var newPath = path._Path.ToList();
                newPath[index] = value;
                path = new PathApiWrapper(newPath);
            }
        }

        [LuaDocsDescription("The number of control points in this stroke")]
        public int count => _Stroke?.m_ControlPoints.Length ?? 0;

        [LuaDocsDescription("Deletes the current stroke")]
        [LuaDocsExample("myStroke:Delete()")]
        public void Delete()
        {
            SketchMemoryScript.m_Instance.RemoveMemoryObject(_Stroke);
            _Stroke.Uncreate();
            _Stroke = null;
        }

        [LuaDocsDescription("Adds this stroke to the current selection")]
        [LuaDocsExample("myStroke:Select()")]
        public void Select()
        {
            SelectionManager.m_Instance.SelectStrokes(new List<Stroke> { _Stroke });
        }

        [LuaDocsDescription("Adds multiple strokes to the current selection")]
        [LuaDocsExample("Stroke:SelectMultiple(0, 4) --Adds the first 5 strokes on the sketch")]
        [LuaDocsParameter("from", "Start stroke index (0 is the first stroke that was drawn")]
        [LuaDocsParameter("to", "End stroke index")]
        public static void SelectRange(int from, int to) => ApiMethods.SelectStrokes(from, to);

        [LuaDocsDescription("Joins joins multiple strokes into one stroke")]
        [LuaDocsExample("newStroke = Stroke:Join(0, 10)")]
        [LuaDocsParameter("from", "Start stroke index (0 is the first stroke that was drawn")]
        [LuaDocsParameter("to", "End stroke index")]
        public StrokeApiWrapper JoinRange(int from, int to) => new StrokeApiWrapper(ApiMethods.JoinStrokes(from, to));

        [LuaDocsDescription("Joins a stroke with the previous stroke")]
        [LuaDocsExample("newStroke = myStroke:JoinPrevious()")]
        public StrokeApiWrapper JoinToPrevious() => new StrokeApiWrapper(ApiMethods.JoinStroke());

        [LuaDocsDescription("Joins a stroke with the previous stroke")]
        [LuaDocsExample("newStroke = myStroke:JoinPrevious()")]
        [LuaDocsParameter("stroke2", "The stroke to join to this one")]
        public StrokeApiWrapper Join(StrokeApiWrapper stroke2) => new StrokeApiWrapper(ApiMethods.JoinStrokes(_Stroke, stroke2._Stroke));

        [LuaDocsDescription("Imports the file with the specified name from the user's Sketches folder and merges it's strokes into the current sketch")]
        [LuaDocsExample("Stroke:MergeFrom(string name)")]
        [LuaDocsParameter("name", "Name of the file to be merged")]
        public void MergeFrom(string name) => ApiMethods.MergeNamedFile(name);
    }

}
