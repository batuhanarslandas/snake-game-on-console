using System.Timers;
class Game
{
    public static void Main(string[] args)
    {
        new Snake_Game().oyunu_baslat();
    }
}

class Snake_Game
{
    List<Snake> snakes = new List<Snake>();
    Snake yem = new Snake();
    char lastKeyChar = 'w';
    int time = 0;
    static int score = 0;
    System.Timers.Timer timer = new System.Timers.Timer(Convert.ToDouble(100/((score + 1) * 2)));

    public void oyunu_baslat()
    {
        Console.CursorVisible = false;
        Console.SetWindowSize(150, 50);

        snakes.Add(snake_item_generator(15,38,'0'));
        snakes.Add(snake_item_generator(15, 39,'*'));
        snakes.Add(snake_item_generator(15, 40,'*'));
        snakes.Add(snake_item_generator(15, 41,'*'));
        snakes.Add(snake_item_generator(15, 42,'*'));

        foreach (Snake snake in snakes)
        {
            Console.SetCursorPosition(snake.position.row, snake.position.col);
            Console.Write(snake.type);
        }

        yem_olustur();

        timer.AutoReset = true;
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        timer.Start();

        while (true)
        {
            var c = (Console.ReadKey(true).KeyChar);
            if (!((c == 'w' && lastKeyChar == 's') || (c == 's' && lastKeyChar == 'w') || (c == 'd' && lastKeyChar == 'a') || c == 'a' && lastKeyChar == 'd'))
                lastKeyChar = c;

        }
    }

    public void oyun_bitti()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("OYUN BİTTİ");
        Console.WriteLine("Score: {0}", score);
    }
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        hareket_ettir(lastKeyChar);
        time += 1;
    }

    public void hareket_ettir(char c)
    {
        Position lastPosition = new Position();
        Boolean b = false;
        lastKeyChar = c;
        if (time > 40)
        {
            switch (c)
            {
                case 'w':
                    for (var i = 0; i < snakes.Count; i++)
                    {
                        Snake snake = snakes[i];
                        if (i != 0)
                        {
                            var x = snake.position.col;
                            var y = snake.position.row;
                            writeConsole(y, x, ' ');

                            snake.position.col = lastPosition.col;
                            snake.position.row = lastPosition.row;

                            lastPosition.col = x;
                            lastPosition.row = y;
                        }
                        else
                        {
                            lastPosition.col = snake.position.col;
                            lastPosition.row = snake.position.row;
                            writeConsole(lastPosition.row, lastPosition.col, ' ');
                            snake.position.col -= 1;
                            if ((snakes.FindAll(s => s.position.col == snake.position.col && s.position.row == snake.position.row).Count > 1) || snake.position.col == 0)
                            {
                                timer.Stop();
                                oyun_bitti();
                            }
                            if (yem.position.col == snake.position.col && yem.position.row == snake.position.row)
                            {
                                b = true;
                                yem_olustur();
                            }
                        }
                        snakes[i] = snake;
                        writeConsole(snake.position.row, snake.position.col, snake.type);
                    }
                    if (b)
                    {
                        score += 1;
                        snakes.Add(snake_item_generator(lastPosition.row, lastPosition.col, '*'));
                    }
                    break;
                case 'a':
                    for (var i = 0; i < snakes.Count; i++)
                    {
                        Snake snake = snakes[i];
                        if (i != 0)
                        {
                            var x = snake.position.col;
                            var y = snake.position.row;
                            writeConsole(y, x, ' ');

                            snake.position.col = lastPosition.col;
                            snake.position.row = lastPosition.row;

                            lastPosition.col = x;
                            lastPosition.row = y;
                        }
                        else
                        {
                            lastPosition.col = snake.position.col;
                            lastPosition.row = snake.position.row;
                            writeConsole(lastPosition.row, lastPosition.col, ' ');
                            snake.position.row -= 1;
                            if ((snakes.FindAll(s => s.position.col == snake.position.col && s.position.row == snake.position.row).Count > 1) || snake.position.row == 0)
                            {
                                timer.Stop();
                                oyun_bitti();
                            }
                            if (yem.position.col == snake.position.col && yem.position.row == snake.position.row)
                            {
                                b = true;
                                yem_olustur();
                            }
                        }
                        snakes[i] = snake;
                        writeConsole(snake.position.row, snake.position.col, snake.type);
                    }
                    if (b)
                    {
                        score += 1;
                        snakes.Add(snake_item_generator(lastPosition.row, lastPosition.col, '*'));
                    }
                    break;
                case 's':
                    for (var i = 0; i < snakes.Count; i++)
                    {
                        Snake snake = snakes[i];
                        if (i != 0)
                        {
                            var x = snake.position.col;
                            var y = snake.position.row;
                            writeConsole(y, x, ' ');

                            snake.position.col = lastPosition.col;
                            snake.position.row = lastPosition.row;

                            lastPosition.col = x;
                            lastPosition.row = y;
                        }
                        else
                        {
                            lastPosition.col = snake.position.col;
                            lastPosition.row = snake.position.row;
                            writeConsole(lastPosition.row, lastPosition.col, ' ');
                            snake.position.col += 1;
                            if ((snakes.FindAll(s => s.position.col == snake.position.col && s.position.row == snake.position.row).Count > 1) || snake.position.col == Console.WindowHeight - 1)
                            {
                                timer.Stop();
                                oyun_bitti();
                            }
                            if (yem.position.col == snake.position.col && yem.position.row == snake.position.row)
                            {
                                b = true;
                                yem_olustur();
                            }
                        }
                        snakes[i] = snake;
                        writeConsole(snake.position.row, snake.position.col, snake.type);
                    }
                    if (b)
                    {
                        score += 1;
                        snakes.Add(snake_item_generator(lastPosition.row, lastPosition.col, '*'));
                    }

                    break;
                case 'd':
                    for (var i = 0; i < snakes.Count; i++)
                    {
                        Snake snake = snakes[i];
                        if (i != 0)
                        {
                            var x = snake.position.col;
                            var y = snake.position.row;
                            writeConsole(y, x, ' ');

                            snake.position.col = lastPosition.col;
                            snake.position.row = lastPosition.row;

                            lastPosition.col = x;
                            lastPosition.row = y;
                        }
                        else
                        {
                            lastPosition.col = snake.position.col;
                            lastPosition.row = snake.position.row;
                            writeConsole(lastPosition.row, lastPosition.col, ' ');
                            snake.position.row += 1;
                            if ((snakes.FindAll(s => s.position.col == snake.position.col && s.position.row == snake.position.row).Count > 1) || snake.position.row == Console.WindowWidth-1)

                            {
                                timer.Stop();
                                oyun_bitti();
                            }
                            if (yem.position.col == snake.position.col && yem.position.row == snake.position.row)
                            {
                                b = true;
                                yem_olustur();
                            }
                        }
                        snakes[i] = snake;
                        writeConsole(snake.position.row, snake.position.col, snake.type);
                    }
                    if (b)
                    {
                        score += 1;
                        snakes.Add(snake_item_generator(lastPosition.row, lastPosition.col, '*'));
                    }
                    break;

            }
        }
    }

    public void yem_olustur()
    {
        Random rand = new Random();

        while (true)
        {
            var col = rand.Next(1, 149);
            var row = rand.Next(1, 49);
            if (snakes.FindIndex(snake => snake.position.row == row && snake.position.col == col) == -1)
            {
                yem = snake_item_generator(col, row, '+');
                writeConsole(yem.position.row, yem.position.col, yem.type); 
                break;
            }
        }
    }

    public void writeConsole(int row, int col, char text)
    {
        Console.SetCursorPosition(row, col);
        Console.Write(text);
    }
    public Snake snake_item_generator(int row, int col, char type)
    {
        Position position = new Position();
        Snake snake = new Snake();
        position.row = row;
        position.col = col;
        snake.position = position;
        snake.type = type;
        return snake;
    }
}

class Snake
{
    public Position position = new Position();
    public char type;
}
class Position
{
    public int col;
    public int row;
}