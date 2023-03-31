# Arkanoid
Bei Beginn des Spiels wird der Ball aus der Spielmitte in Richtung Paddle geschickt und das Spiel beginnt. 
Man hat insgesamt 3 Leben die über dem Spielfeld angezeigt werden rechts daneben ist der aktuelle Score zusehen. 

Das Spiel endet wenn man entweder das Spiel gewinnt, also alle Blöcke zerstört oder seine 3 Leben verliert, danach erscheint der GameOverScreen mit dem ereichten Score.

Es gibt 35 Cubes mit verschiedenen Farben, die Cubes haben unterschiedliche Hitpoints die für jeden Block individuell eingestellt werden können. Somit müssen einige Blöcke öfters als einmal getroffen werden um zu verschwinden.

Es wurden zwei PowerUps implementiert einmal die erweiterung des Paddles und zweitens ein Slow Motion Effekt.
Die Powerups werden zufällig bei der Zerstörung der Cubes generiert und fallen gerade nach unten, wenn sie mit dem Paddle aufgefangen werden aktiviert sich der Effekt sonst wird das PowerUp zerstört. 
- SlowMotion (Türkise Sphere) 
--> Spiel wird für einige Sekunden verlangsamt, währenddessen ist es nicht möglich das gleiche Powerup erneut aufzunehmen.
- WiderPaddle (Dunkelgrüne Sphere)
--> Das Paddle wird vegrößert 

GitHub: http://www.github.com/ssecka/Arkanoid/tree/master
--> Das Projekt liegt im master branch
Youtube: https://www.youtube.com/watch?v=5aHyWfcKPFo


