﻿// Copyright 2022 The Open Brush Authors
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

namespace TiltBrush
{
    public class PolyhydraOpPopupToolsButton : BaseButton
    {

        public enum ToolTypes
        {
            Next,
            Previous,
            Delete
        }
        public ToolTypes ToolType;

        protected override void OnButtonPressed()
        {
            switch (ToolType)
            {
                case ToolTypes.Delete:
                    GetComponentInParent<PolyhydraPanel>().HandleOpDelete();
                    break;
                case ToolTypes.Next:
                    GetComponentInParent<PolyhydraPanel>().HandleOpMove(1);
                    break;
                case ToolTypes.Previous:
                    GetComponentInParent<PolyhydraPanel>().HandleOpMove(-1);
                    break;
            }
        }
    }


}