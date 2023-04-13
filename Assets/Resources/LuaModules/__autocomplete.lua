tool.startPosition = nil
tool.endPosition = nil
tool.vector = nil
function unityColor.greyscale(col) end
function unityColor.maxColorComponent(col) end
function unityColor.toHtmlString(col) end
function unityColor.parseHtmlString(html) end
function unityColor.lerp(a, b, t) end
function unityColor.lerpUnclamped(a, b, t) end
function unityColor.hsvToRgb(h, s, v) end
function unityColor.rgbToHsv(rgb) end
function unityColor.add(a, b) end
function unityColor.subtract(a, b) end
function unityColor.multiply(a, b) end
function unityColor.divide(a, b) end
function unityColor.equals(a, b) end
function unityColor.notEquals(a, b) end
unityMathf.deg2Rad = nil
unityMathf.epsilon = nil
unityMathf.infinity = nil
unityMathf.negativeInfinity = nil
unityMathf.pI = nil
unityMathf.rad2Deg = nil
function unityMathf.abs(f) end
function unityMathf.acos(f) end
function unityMathf.approximately(a, b) end
function unityMathf.asin(f) end
function unityMathf.atan(f) end
function unityMathf.atan2(y, x) end
function unityMathf.ceil(f) end
function unityMathf.clamp(value, min, max) end
function unityMathf.clamp01(value) end
function unityMathf.closestPowerOfTwo(value) end
function unityMathf.cos(f) end
function unityMathf.deltaAngle(current, target) end
function unityMathf.exp(power) end
function unityMathf.floor(f) end
function unityMathf.inverseLerp(a, b, value) end
function unityMathf.isPowerOfTwo(value) end
function unityMathf.lerp(a, b, t) end
function unityMathf.lerpAngle(a, b, t) end
function unityMathf.lerpUnclamped(a, b, t) end
function unityMathf.log(f, p) end
function unityMathf.log10(f) end
function unityMathf.max(a, b) end
function unityMathf.max(values) end
function unityMathf.min(a, b) end
function unityMathf.min(values) end
function unityMathf.moveTowards(current, target, maxDelta) end
function unityMathf.nextPowerOfTwo(value) end
function unityMathf.perlinNoise(x, y) end
function unityMathf.pingPong(t, length) end
function unityMathf.pow(f, p) end
function unityMathf.repeater(t, length) end
function unityMathf.round(f) end
function unityMathf.sign(f) end
function unityMathf.sin(f) end
function unityMathf.sqrt(f) end
function unityMathf.smoothStep(from, to, t) end
function unityMathf.tan(f) end
function unityMathf.sinh(f) end
function unityMathf.cosh(f) end
function unityMathf.tanh(f) end
unityQuaternion.identity = nil
unityQuaternion.kEpsilon = nil
function unityQuaternion.angle(a, b) end
function unityQuaternion.angleAxis(angle, axis) end
function unityQuaternion.dot(a, b) end
function unityQuaternion.fromToRotation(from, to) end
function unityQuaternion.inverse(a) end
function unityQuaternion.lerp(a, b, t) end
function unityQuaternion.lerpUnclamped(a, b, t) end
function unityQuaternion.lookRotation(forward, up) end
function unityQuaternion.normalize(a) end
function unityQuaternion.rotateTowards(from, to, maxDegreesDelta) end
function unityQuaternion.slerp(a, b, t) end
function unityQuaternion.slerpUnclamped(a, b, t) end
function unityQuaternion.multiply(a, b) end
function unityQuaternion.equals(a, b) end
unityVector2.down = nil
unityVector2.left = nil
unityVector2.negativeInfinity = nil
unityVector2.one = nil
unityVector2.positiveInfinity = nil
unityVector2.right = nil
unityVector2.up = nil
unityVector2.zero = nil
function unityVector2.angle(a, b) end
function unityVector2.clampMagnitude(v, maxLength) end
function unityVector2.distance(a, b) end
function unityVector2.magnitude(a) end
function unityVector2.sqrMagnitude(a) end
function unityVector2.dot(a, b) end
function unityVector2.lerp(a, b, t) end
function unityVector2.lerpUnclamped(a, b, t) end
function unityVector2.max(a, b) end
function unityVector2.min(a, b) end
function unityVector2.moveTowards(current, target, maxDistanceDelta) end
function unityVector2.normalized(a) end
function unityVector2.reflect(a, b) end
function unityVector2.scale(a, b) end
function unityVector2.signedAngle(from, to, axis) end
function unityVector2.slerp(a, b, t) end
function unityVector2.slerpUnclamped(a, b, t) end
function unityVector2.add(a, b) end
function unityVector2.subtract(a, b) end
function unityVector2.multiply(a, b) end
function unityVector2.divide(a, b) end
function unityVector2.equals(a, b) end
function unityVector2.notEquals(a, b) end
unityVector3.back = nil
unityVector3.down = nil
unityVector3.forward = nil
unityVector3.left = nil
unityVector3.negativeInfinity = nil
unityVector3.one = nil
unityVector3.positiveInfinity = nil
unityVector3.right = nil
unityVector3.up = nil
unityVector3.zero = nil
function unityVector3.angle(a, b) end
function unityVector3.clampMagnitude(v, maxLength) end
function unityVector3.cross(a, b) end
function unityVector3.distance(a, b) end
function unityVector3.magnitude(a) end
function unityVector3.sqrMagnitude(a) end
function unityVector3.dot(a, b) end
function unityVector3.lerp(a, b, t) end
function unityVector3.lerpUnclamped(a, b, t) end
function unityVector3.max(a, b) end
function unityVector3.min(a, b) end
function unityVector3.moveTowards(current, target, maxDistanceDelta) end
function unityVector3.normalize(a) end
function unityVector3.project(a, b) end
function unityVector3.projectOnPlane(vector, planeNormal) end
function unityVector3.reflect(a, b) end
function unityVector3.rotateTowards(current, target, maxRadiansDelta, maxMagnitudeDelta) end
function unityVector3.scale(a, b) end
function unityVector3.signedAngle(from, to, axis) end
function unityVector3.slerp(a, b, t) end
function unityVector3.slerpUnclamped(a, b, t) end
function unityVector3.add(a, b) end
function unityVector3.subtract(a, b) end
function unityVector3.multiply(a, b) end
function unityVector3.divide(a, b) end
function unityVector3.equals(a, b) end
function unityVector3.notEquals(a, b) end
unityRandom.insideUnitCircle = nil
unityRandom.insideUnitSphere = nil
unityRandom.onUnitSphere = nil
unityRandom.rotation = nil
unityRandom.rotationUniform = nil
unityRandom.value = nil
unityRandom.ColorHSV = nil
function unityRandom.InitState(seed) end
function unityRandom.Range(min, max) end
function unityRandom.Range(min, max) end
app.time = nil
app.frames = nil
app.currentScale = nil
app.lastSelectedStroke = nil
app.lastStroke = nil
app.environment = nil
app.clipboardText = nil
app.clipboardImage = nil
function app.physics(active) end
function app.undo() end
function app.redo() end
function app.addListener(a) end
function app.resetPanels() end
function app.showScriptsFolder() end
function app.showExportFolder() end
function app.showSketchesFolder(a) end
function app.straightEdge(a) end
function app.autoOrient(a) end
function app.viewOnly(a) end
function app.autoSimplify(a) end
function app.disco(a) end
function app.profiling(a) end
function app.postProcessing(a) end
function app.draftingVisible() end
function app.draftingTransparent() end
function app.draftingHidden() end
function app.watermark(a) end
function app.readFile(path) end
function app.setFont(fontData) end
brush.timeSincePressed = nil
brush.timeSinceReleased = nil
brush.triggerIsPressed = nil
brush.triggerIsPressedThisFrame = nil
brush.distanceMoved = nil
brush.distanceDrawn = nil
brush.position = nil
brush.rotation = nil
brush.direction = nil
brush.size = nil
brush.pressure = nil
brush.type = nil
brush.speed = nil
brush.colorRgb = nil
brush.colorHsv = nil
brush.colorHtml = nil
brush.lastColorPicked = nil
brush.lastColorPickedHsv = nil
function brush.colorJitter() end
function brush.resizeBuffer(size) end
function brush.setBufferSize(size) end
function brush.pastPosition(back) end
function brush.pastRotation(back) end
function brush.forcePaintingOn(active) end
function brush.forcePaintingOff(active) end
function brush.forceNewStroke() end
function camerapath.render() end
function camerapath.toggleVisuals() end
function camerapath.togglePreview() end
function camerapath.delete() end
function camerapath.record() end
function camerapath.sample(time, loop, pingpong) end
function draw.path(path) end
function draw.paths(paths) end
function draw.polygon(sides, tr) end
function draw.text(text, tr) end
function draw.svg(svg, tr) end
function draw.cameraPath(index) end
function guides.addCube(tr) end
function guides.addSphere(tr) end
function guides.addCapsule(tr) end
function guides.addCone(tr) end
function guides.addEllipsoid(tr) end
function guides.select(index) end
function guides.moveTo(index, position) end
function guides.scale(index, scale) end
function guides.toggle() end
function headset.resizeBuffer(size) end
function headset.setBufferSize(size) end
function headset.pastPosition(count) end
function headset.pastRotation(count) end
function images.import(location) end
function images.select(index) end
function images.moveTo(index, position) end
function images.getTransform(index) end
function images.getPosition(index) end
function images.getRotation(index) end
function images.setPosition(index, position) end
function images.setRotation(index, rotation) end
layers.getActive = nil
layers.count = nil
function layers.getPosition(index) end
function layers.setPosition(index, position) end
function layers.getRotation(index) end
function layers.setRotation(index, rotation) end
function layers.centerPivot(index) end
function layers.showPivot(index) end
function layers.hidePivot(index) end
function layers.getTransform(index) end
function layers.setTransform(index, newTransform) end
function layers.add() end
function layers.clear(index) end
function layers.delete(index) end
function layers.squash(sourceLayer, destinationLayer) end
function layers.activate(index) end
function layers.show(index) end
function layers.hide(index) end
function layers.toggle(index) end
function models.select(index) end
function models.getTransform(index) end
function models.getPosition(index) end
function models.getRotation(index) end
function models.setPosition(index, position) end
function models.setRotation(index, rotation) end
function path.fromSvg(svg, scale) end
function path.fromSvgMultiple(svg) end
function path.transform(path, transform) end
function path.translate(path, amount) end
function path.rotate(path, amount) end
function path.scale(path, amount) end
visualizer.sampleRate = nil
visualizer.duration = nil
function visualizer.enableScripting(name) end
function visualizer.disableScripting() end
function visualizer.setWaveform(data) end
function visualizer.setFft(data1, data2, data3, data4) end
function visualizer.setBeats(x, y, z, w) end
function visualizer.setBeatAccumulators(x, y, z, w) end
function visualizer.setBandPeak(peak) end
function selection.duplicate() end
function selection.group() end
function selection.invert() end
function selection.flip() end
function selection.recolor() end
function selection.rebrush() end
function selection.resize() end
function selection.trim(count) end
function selection.selectAll() end
function sketch.open(name) end
function sketch.save(overwrite) end
function sketch.saveAs(name) end
function sketch.export() end
function sketch.newSketch() end
spectator.position = nil
spectator.rotation = nil
function spectator.turn(angle) end
function spectator.turnX(angle) end
function spectator.turnZ(angle) end
function spectator.direction(direction) end
function spectator.lookAt(position) end
function spectator.mode(mode) end
function spectator.show(type) end
function spectator.hide(type) end
function spectator.toggle() end
function spectator.on() end
function spectator.off() end
strokes.count = nil
function strokes.delete(index) end
function strokes.select(index) end
function strokes.selectMultiple(from, to) end
function strokes.join(from, to) end
function strokes.joinPrevious() end
function strokes.import(name) end
symmetry.transform = nil
symmetry.position = nil
symmetry.rotation = nil
symmetry.brushOffset = nil
symmetry.wandOffset = nil
symmetry.direction = nil
function symmetry.mirror() end
function symmetry.doubleMirror() end
function symmetry.twoHandeded() end
function symmetry.summonWidget() end
function symmetry.spin(rot) end
function symmetry.ellipse(angle, minorRadius) end
function symmetry.square(angle) end
function symmetry.superellipse(angle, n, a, b) end
function symmetry.rsquare(angle, halfSideLength, cornerRadius) end
function symmetry.polygon(angle, numSides, radius) end
function symmetry.setColors(colors) end
function symmetry.getColors() end
function symmetry.setBrushes(brushes) end
function symmetry.getBrushNames() end
function symmetry.getBrushGuids() end
function symmetry.pointsToPolar(cartesianPoints) end
function timer.set(fn, interval, delay, repeats) end
function timer.unset(fn) end
turtle.transform = nil
turtle.position = nil
turtle.rotation = nil
function turtle.moveTo(position) end
function turtle.moveBy(amount) end
function turtle.move(amount) end
function turtle.draw(amount) end
function turtle.drawPolygon(sides, radius, angle) end
function turtle.drawText(text) end
function turtle.drawSvg(svg) end
function turtle.turnY(angle) end
function turtle.turnX(angle) end
function turtle.turnZ(angle) end
function turtle.lookAt(amount) end
function turtle.lookForwards() end
function turtle.lookUp() end
function turtle.lookDown() end
function turtle.lookLeft() end
function turtle.lookRight() end
function turtle.lookBackwards() end
function turtle.homeReset() end
function turtle.homeSet() end
function turtle.transformPush() end
function turtle.transformPop() end
user.position = nil
user.rotation = nil
wand.position = nil
wand.rotation = nil
wand.direction = nil
wand.pressure = nil
wand.speed = nil
function wand.resizeBuffer(size) end
function wand.setBufferSize(size) end
function wand.pastPosition(back) end
function wand.pastRotation(back) end
function waveform.sine(time, frequency) end
function waveform.cosine(time, frequency) end
function waveform.triangle(time, frequency) end
function waveform.sawtooth(time, frequency) end
function waveform.square(time, frequency) end
function waveform.pulse(time, frequency, pulseWidth) end
function waveform.exponent(time, frequency) end
function waveform.power(time, frequency, power) end
function waveform.parabolic(time, frequency) end
function waveform.exponentialSawtooth(time, frequency, exponent) end
function waveform.perlinNoise(time, frequency) end
function waveform.whiteNoise() end
function waveform.brownNoise(previous) end
function waveform.blueNoise(previous) end
function waveform.sine(time, frequency, duration, sampleRate, amplitude) end
function waveform.cosine(time, frequency, duration, sampleRate, amplitude) end
function waveform.triangle(time, frequency, duration, sampleRate, amplitude) end
function waveform.sawtooth(time, frequency, duration, sampleRate, amplitude) end
function waveform.square(time, frequency, duration, sampleRate, amplitude) end
function waveform.exponent(time, frequency, duration, sampleRate, amplitude) end
function waveform.parabolic(time, frequency, duration, sampleRate, amplitude) end
function waveform.pulse(time, frequency, pulseWidth, duration, sampleRate, amplitude) end
function waveform.power(time, frequency, power, duration, sampleRate, amplitude) end
function waveform.exponentialSawtoothWave(time, frequency, exponent, duration, sampleRate, amplitude) end
function waveform.perlinNoise(time, frequency, duration, sampleRate, amplitude) end
function waveform.whiteNoise(duration, sampleRate, amplitude) end
function waveform.brownNoise(previous, duration, sampleRate, amplitude) end
function waveform.blueNoise(previous, duration, sampleRate, amplitude) end
