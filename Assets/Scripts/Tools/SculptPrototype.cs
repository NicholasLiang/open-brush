﻿// CTODO: adjust copyright
// Copyright 2020 The Tilt Brush Authors
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TiltBrush
{
  public class SculptPrototype : ToggleStrokeModificationTool
  {
    private bool m_AtLeastOneModificationMade = false;

    override public void Init()
    {
      base.Init();
      Debug.Log("Sculpt prototype initialized!");
    }

    override public void EnableTool(bool bEnable)
    {
      // Call this after setting up our tool's state.
      base.EnableTool(bEnable);
      // CTODO: change the material of all strokes to some wireframe shader.
      HideTool(!bEnable);
    }

    public void FinalizeSculptingBatch()
    {
      m_AtLeastOneModificationMade = false;
    }

    override public void OnUpdateDetection() {
      if (!m_CurrentlyHot && m_ToolWasHot) {
        FinalizeSculptingBatch();
        ResetToolRotation();
        ClearGpuFutureLists();
      }
    }


    //CTODO: This is an absolute mess.
    override protected bool HandleIntersectionWithBatchedStroke(BatchSubset rGroup)
    {
      // Metadata of target stroke
      var stroke = rGroup.m_Stroke;
      Batch parentBatch = rGroup.m_ParentBatch;
      int firstIdx = rGroup.m_StartVertIndex;
      int lastIdx = firstIdx + rGroup.m_VertLength;

      var newVertices = new List<Vector3>(parentBatch.m_Geometry.m_Vertices);
      // Tool position adjusted by canvas transformations
      var toolPos = m_CurrentCanvas.Pose.inverse * m_ToolTransform.position;

      for (int i = firstIdx; i < lastIdx; i++)
      {

          // Distance from vertex to pointer
          float distance = Vector3.Distance(newVertices[i], toolPos);
          if (distance <= GetSize() / m_CurrentCanvas.Pose.scale)
          {
              // CTODO: Make this depend on distance
              float strength = 0.2f;
              Vector3 direction = (newVertices[i] - toolPos).normalized;
              Vector3 newVert = newVertices[i] + direction * 0.2f;
              newVertices[i] = newVert;
              PlayModifyStrokeSound();
              InputManager.m_Instance.TriggerHaptics(InputManager.ControllerName.Brush, m_HapticsToggleOn);
          }
      }
      Debug.Log("Sculpting modification made");

      SketchMemoryScript.m_Instance.MemorizeStrokeSculpt(rGroup, newVertices, !m_AtLeastOneModificationMade);
      m_AtLeastOneModificationMade = true;
      // parentBatch.m_Geometry.m_Vertices = newVertices;
      // parentBatch.DelayedUpdateMesh();
      return true;
    }
  }

} // namespace TiltBrush