color(128, 0, 0)
for x = 0, math.pi * 10, 0.1 do
    y = math.sin(x)
    draw(Segment(Point(x * 10, y * 10), Point(150, 150)))
end

color(128, 0, 128)
for x = 0, math.pi * 10, 0.1 do
    y = math.sin(x)
    draw(Segment(Point(y * 10, x * 10), Point(150, 150)))
end

color(0, 128, 0)
for x = 10, math.pi * 10, 0.1 do
    y = math.sin(x)
    draw(Segment(Point(y * 10, x * 10), Point(150, 150)))
end

color(0, 0, 128)
for x = 10, math.pi * 10, 0.1 do
    y = math.sin(x)
    draw(Segment(Point(x * 10, y * 10), Point(150, 150)))
end