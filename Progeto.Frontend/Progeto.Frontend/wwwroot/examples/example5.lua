p1 = Point(-50, 50)
p2 = Point(50, 50)
p3 = Point(50, -50)
p4 = Point(-50, -50)

base1 = Segment(p1, p2)
base2 = Segment(p2, p3)
base3 = Segment(p3, p4)
base4 = Segment(p4, p1)

color(128, 64, 0)
width(2)
draw(base1)
draw(base2)
draw(base3)
draw(base4)

p5 = Point(0, -100)

roof1 = Segment(p4, p5)
roof2 = Segment(p5, p3)
roof3 = Segment(p3, p4)

color(255, 0, 0)
width(2)
draw(roof1)
draw(roof2)
draw(roof3)

p6 = Point(-15, 50)
p7 = Point(15, 50)
p8 = Point(15, 10)
p9 = Point(-15, 10)

door1 = Segment(p6, p7)
door2 = Segment(p7, p8)
door3 = Segment(p8, p9)
door4 = Segment(p9, p6)

color(0, 0, 255)
width(2)
draw(door1)
draw(door2)
draw(door3)
draw(door4)

window1_center = Point(-30, -20)
window2_center = Point(30, -20)
window_radius = 10

window1 = Circle(window1_center, window_radius)
window2 = Circle(window2_center, window_radius)

color(0, 255, 255)
width(2)
draw(window1)
draw(window2)

print("Casa dibujada con exito")
