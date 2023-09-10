﻿// Copyright 2020 The Tilt Brush Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;

namespace TiltBrush
{
    public class RemovePathKnotCommand : BaseCommand
    {
        private MovementPathWidget m_Widget;
        private TrTransform m_RemovedXf;
        private int m_KnotIndex;
        private PathT m_PathT;
        public MovementPathKnot Knot { get; }

        public RemovePathKnotCommand(MovementPathWidget widget, MovementPathKnot knot,
                                     TrTransform removeXf, BaseCommand parent = null)
            : base(parent)
        {
            Knot = knot;
            m_Widget = widget;
            m_RemovedXf = removeXf;

            // If we're removing a position knot, remember its ordered index. This is necessary
            // because it's probable that the path will change after removal and Undo won't be able
            // to place the knot back on the path at the current position.
            if (Knot.KnotType == MovementPathKnot.Type.Position)
            {
                m_KnotIndex = m_Widget.Path.PositionKnots.IndexOf((MovementPathPositionKnot)Knot);
                m_PathT = new PathT();
            }
            else
            {
                m_PathT = Knot.PathT;
            }
        }

        public override bool NeedsSave { get => true; }

        protected override void OnUndo()
        {
            // The scale of path widgets is arbitrary.  However, the scale should be one at knot creation
            // time so newly added knots have appropriate mesh scales.
            m_Widget.transform.localScale = Vector3.one;

            switch (Knot.KnotType)
            {
                case MovementPathKnot.Type.Position:
                    m_Widget.Path.InsertPositionKnot((MovementPathPositionKnot)Knot, m_KnotIndex);
                    break;
                case MovementPathKnot.Type.Rotation:
                    m_Widget.Path.AddRotationKnot((MovementPathRotationKnot)Knot, m_PathT);
                    break;
                case MovementPathKnot.Type.Speed:
                    m_Widget.Path.AddSpeedKnot((MovementPathSpeedKnot)Knot, m_PathT);
                    break;
                case MovementPathKnot.Type.Fov:
                    m_Widget.Path.AddFovKnot((MovementPathFovKnot)Knot, m_PathT);
                    break;
            }

            Knot.gameObject.SetActive(true);
            App.Switchboard.TriggerCameraPathKnotChanged();
            WidgetManager.m_Instance.CameraPathsVisible = true;
        }

        protected override void OnRedo()
        {
            m_Widget.Path.RemoveKnot(Knot);
            Knot.gameObject.SetActive(false);
            WidgetManager.m_Instance.ValidateCurrentCameraPath();
            App.Switchboard.TriggerCameraPathKnotChanged();
            WidgetManager.m_Instance.CameraPathsVisible = true;
        }
    }
} // namespace TiltBrush
