Settings = {
    description="Draws a cube",
    previewType="cube"
}

Parameters = {
    spacing = {label="Point Spacing", type="float", min=0.1, max=1, default=0.1},
    inset = {label="Inset amount", type="float", min=0, max=0.9, default=0.1},
}

function createFace(center, normal, up)

    local right = Vector3:Cross(normal, up)
    local rotation = Rotation:LookRotation(normal, up)

    local normal = normal:Multiply(inset)
    local center = center:Add(normal)

    local up = up:Multiply(1 - inset)
    local right = right:Multiply(1 - inset)

    local topLeft = (center:Add(up)):Subtract(right)
    local topRight = (center:Add(up)):Add(right)
    local bottomRight = (center:Subtract(up)):Add(right)
    local bottomLeft = (center:Subtract(up)):Subtract(right)

    local face = Path:New()
    face:Insert(Transform:New(topLeft, rotation))
    face:Insert(Transform:New(topRight, rotation))
    face:Insert(Transform:New(bottomRight, rotation))
    face:Insert(Transform:New(bottomLeft, rotation))
    face:Insert(Transform:New(topLeft, rotation)) -- to close the loop
    face:Resample(spacing) -- Create evenly spaced points

    return face
end

function OnTriggerReleased()

    paths = MultiPath:New()
    paths:Insert(createFace(Vector3.forward, Vector3.forward, Vector3.up)) -- front face
    paths:Insert(createFace(Vector3.right, Vector3.right, Vector3.up)) -- right face
    paths:Insert(createFace(Vector3.back, Vector3.back, Vector3.up)) -- back face
    paths:Insert(createFace(Vector3.left, Vector3.left, Vector3.up)) -- left face
    paths:Insert(createFace(Vector3.up, Vector3.up, Vector3.forward)) -- top face
    paths:Insert(createFace(Vector3.down, Vector3.down, Vector3.forward)) -- bottom face

    return paths
end