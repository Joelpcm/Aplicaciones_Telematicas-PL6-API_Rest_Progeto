-- Crear puntos iniciales
p1 = Point(-50, -50)
p2 = Point(50, -50)
p3 = Point(0, 50)

s1 = Segment(p1, p2)
s2 = Segment(p2, p3)
s3 = Segment(p3, p1)

color(0, 0, 255)
width(2)
draw(s1)
draw(s2)
draw(s3)

c1 = Circle(p1, 10)
c2 = Circle(p2, 10)
c3 = Circle(p3, 10)

color(255, 0, 0)
width(1)
draw(c1)
draw(c2)
draw(c3)

l1 = Segment(c1.Center, c2.Center)
l2 = Segment(c2.Center, c3.Center)
l3 = Segment(c3.Center, c1.Center)

color(0, 255, 0)
width(1.5)
draw(l1)
draw(l2)
draw(l3)

m1 = s1.MiddlePoint
m2 = s2.MiddlePoint
m3 = s3.MiddlePoint

color(255, 255, 0) 
width(3)
draw(m1)
draw(m2)
draw(m3)

center = Point((p1.x + p2.x + p3.x) / 3, (p1.y + p2.y + p3.y) / 3) 
radius = math.min(s1.Length, s2.Length, s3.Length) / 4
inscribedCircle = Circle(center, radius)

color(128, 0, 128)
width(2)
draw(inscribedCircle)

centroidToMid = Segment(center, m1)
color(0, 128, 128)
width(2)
draw(centroidToMid)

print("Ejemplo 4 completo")