p1 = Point(-22.20008, -17.12996)
r1 = 10

p2 = Point(79.79563, -95.67755)
r2 = 5

c1 = Circle(p1, r1)
c2 = Circle(p2, r2)

draw(c1)
draw(c2)

sc = Segment(c1.Center, c2.Center)
vc = sc.Line.Normal
vc:Normalize()

width(1)
color(128, 128, 0)
draw(sc)

v = c1.Center + vc * c1.Radius
p11 = Point(v.x, v.y)
draw(p11)

v = c1.Center - vc * c1.Radius
p12 = Point(v.x, v.y)
draw(p12)

v = c2.Center + vc * c2.Radius
p21 = Point(v.x, v.y)
draw(p21)

v = c2.Center - vc * c2.Radius
p22 = Point(v.x, v.y)
draw(p22)

st = Segment(p11, p21)
sb = Segment(p12, p22)

color(128, 128, 255)
draw(st)
draw(sb)
