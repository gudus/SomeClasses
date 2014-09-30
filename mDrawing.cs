    public class mDrawing
    {
        public class Vector2
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        /// <summary>
        /// Количество углов в масиве точек
        /// </summary>
        /// <param name="list">Список точек</param>
        /// <param name="angle">Угол между тремя точками</param>
        /// <param name="error">Погрешность угла</param>
        /// <param name="stepCount">Проверка угла через каждые n точек(точек между точками проверки)</param>
        /// <returns></returns>
        public int GetCountVectex(List<Vector2> list, double angle, double error, int stepCount)
        {
            List<Vector2> listTemps = new List<Vector2>();
            int count = 0;
            string angles = "";
            string testA = "";
            for (int i = 0; i < list.Count; i++)
            {
                if ((i + stepCount * 2) < list.Count)
                {
                    //получаем стороны треугольника
                    double a = GetVectorDistance(list[i], list[i + stepCount]);
                    double b = GetVectorDistance(list[i + stepCount], list[i + stepCount * 2]);
                    double c = GetVectorDistance(list[i + stepCount * 2], list[i]);
                    //float d = GetVectorDistance(list[i + stepCount * 2], list[i]);
                    //находим углы треугольника
                    double A = Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * 180 / Math.PI;
                    double B = Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * 180 / Math.PI;
                    double C = Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * 180 / Math.PI;

                    TheLine line1 = new TheLine() { Point1 = list[i], Point2 = list[i + stepCount] };
                    TheLine line2 = new TheLine() { Point1 = list[i + stepCount], Point2 = list[i + stepCount * 2] };

                    double ortLine = CheckOrtogonal(line1, line2);
                    if (ortLine == 0)
                    {
                        count++;
                        angles += " <A=" + A + " <B=" + B + " <C=" + C + "\n";
                    }
                    if (C > angle - error & C < error + angle)
                    {
                        testA += " <A=" + A + " <B=" + B + " <C=" + C + "\n";
                    }
                    //Debug.Log("Lines is ort=" + ortLine);
                    //Debug.Log(" <A=" + A + " <B=" + B + " <C=" + C);
                }
            }
            //Debug.Log(count);
            //Debug.Log("orto=" + angles);
            //Debug.Log("AnglesTest=" + testA);
            return listTemps.Count;
        }
        /// <summary>
        /// Растояние между векторами
        /// </summary>
        /// <param name="from">От</param>
        /// <param name="to">До</param>
        /// <returns></returns>
        public double GetVectorDistance(Vector2 from, Vector2 to)
        {
            return Math.Sqrt(Math.Pow(to.x - from.x, 2) + Math.Pow(to.y - from.y, 2));
        }
        /// <summary>
        /// Проверка массива точек являются ли они линией
        /// </summary>
        /// <param name="list">Список точек</param>
        /// <param name="CheckPointOnLineError">Погрешность от точки до точки</param>
        public void CheckLine(List<Vector2> list,double CheckPointOnLineError)
        {
            if (list.Count > 0)
            {
                Vector2 a = list[0];
                Vector2 b = list[list.Count - 1];
                for (int i = 1; i < list.Count - 1; i++)
                {
                    double poinCheck = GetCheckPointPosition(a, b, list[i]);
                    if (poinCheck > -CheckPointOnLineError & poinCheck < CheckPointOnLineError)
                    {
                        //Debug.Log("Point on the line " + poinCheck);
                    }
                    else if (poinCheck > CheckPointOnLineError)
                    {
                        //Debug.Log("Point left of the line " + poinCheck);
                    }
                    else if (poinCheck < -CheckPointOnLineError)
                    {
                        //Debug.Log("Point right of the line " + poinCheck);
                    }
                }
            }
        }
        /// <summary>
        /// Проверка где находится точка относительно прямой "-" слева, "+" справа, "~0" на прямой
        /// </summary>
        /// <param name="a">начало прямой</param>
        /// <param name="b">конец прямой</param>
        /// <param name="c">точка</param>
        /// <returns></returns>
        private double GetCheckPointPosition(Vector2 a, Vector2 b, Vector2 c)
        {
            //return (b.x - a.x) * (b.y - c.y) - (b.y - a.y) * (b.x - c.x);
            return (c.x - a.x) * (c.y - b.y) - (c.y - a.y) * (c.x - b.x);
        }
        /// <summary>
        /// Отрезок ограниченный двумя точками
        /// </summary>
        public struct TheLine
        {
            public Vector2 Point1;
            public Vector2 Point2;
        }
        /// <summary>
        /// Перпендикулярность линий если 0 то да
        /// </summary>
        /// <param name="pl1"></param>
        /// <param name="pl2"></param>
        /// <returns></returns>
        public double CheckOrtogonal(TheLine pl1, TheLine pl2)
        {
            return (pl1.Point2.x - pl1.Point1.x) * (pl2.Point2.x - pl2.Point1.x) + (pl1.Point2.y - pl1.Point1.y) * (pl2.Point2.y - pl2.Point1.y);
        }
    }
