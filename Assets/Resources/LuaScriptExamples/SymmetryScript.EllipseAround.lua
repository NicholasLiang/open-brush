﻿Settings = {
    description="Radial copies of your stroke with optional color shifts"
}

Parameters = {
    copies={label="Number of copies", type="int", min=1, max=96, default=32},
    eccentricity={label="Eccentricity", type="float", min=0.1, max=3, default=2},
    axisConsistency={label="Axis Consistency", type="float", min=0, max=2, default=1},
}

symmetryHueShift = require "symmetryHueShift"

function Start()
    initialHsv = brush.colorHsv
    --symmetry.transform = {
    --    {0, 10, 6},
    --    {0, 90, 90}
    --}
end

function Main()

    if brush.triggerIsPressedThisFrame then
        symmetryHueShift.generate(copies, initialHsv)
    end

    pointers = {}
    theta = (math.pi * 2.0) / copies

    for i = 0, copies - 1 do
        angle = (symmetry.rotation.y * unityMathf.deg2Rad) + i * theta
        radius = symmetry.ellipse(angle, eccentricity)

        pointer = {
            position={
                symmetry.brushOffset.x * radius,
                symmetry.brushOffset.y,
                unityMathf.lerp(
                    symmetry.brushOffset.z,
                symmetry.brushOffset.z * radius,
                    axisConsistency
                ),
            },
            rotation={0, angle * unityMathf.rad2Deg, 0}
        }
        table.insert(pointers, pointer)
    end
    return pointers
end

function End()
    -- TODO fix brush.colorHsv = initialHsv
end
