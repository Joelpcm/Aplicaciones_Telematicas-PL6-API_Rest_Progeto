-- Centro del sistema solar (el sol)
sun = Point(250, 250)
sun_radius = 20

-- Lista de planetas: órbita, radio, velocidad angular, color
planets = {
    { orbit = 50, radius = 5, speed = 0.5, color = {0, 128, 255} },
    { orbit = 100, radius = 8, speed = 0.3, color = {0, 255, 128} },
    { orbit = 150, radius = 6, speed = 0.2, color = {255, 128, 0} },
    { orbit = 200, radius = 10, speed = 0.1, color = {255, 0, 255} },
}

-- Dibujar el sol
color(255, 204, 0)
draw(Circle(sun, sun_radius))

-- Dibujar órbitas
color(100, 100, 100)
for i, planet in ipairs(planets) do
    draw(Circle(sun, planet.orbit))
end

-- Dibujar trayectorias
for t = 0, 100, 1 do
    for i, planet in ipairs(planets) do
        angle = t * planet.speed
        x = sun.x + math.cos(angle) * planet.orbit
        y = sun.y + math.sin(angle) * planet.orbit
        color(table.unpack(planet.color))
        draw(Point(x, y))
    end
end