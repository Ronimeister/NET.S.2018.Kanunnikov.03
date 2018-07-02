private static int[] FilterArrayValuesUsingStrings(int[] unfilteredArr, int filter)
        {
            List<int> filteredList = new List<int>();
            foreach (int i in unfilteredArr)
            {
                if (i.ToString().Contains(filter.ToString()))
                {
                    filteredList.Add(i);
                }
            }

            return filteredList.ToArray();
        }

        private static int[] FilterArrayValuesUsingDivision(int[] unfilteredArr, int filter)
        {
            int buffElement;
            List<int> filteredList = new List<int>();
            for (int i = 0; i < unfilteredArr.Length; i++)
            {
                buffElement = unfilteredArr[i];
                if (buffElement < 0 && buffElement != Int32.MinValue)
                {
                    buffElement *= -1;
                }
                else if (buffElement == Int32.MinValue)
                {
                    filteredList.Add(unfilteredArr[i]);
                }

                while (buffElement != 0)
                {
                    if (buffElement % 10 == filter)
                    {
                        filteredList.Add(unfilteredArr[i]);
                        break;
                    }

                    buffElement /= 10;
                }
            }

            return filteredList.ToArray();
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] testArray = new int[int.MaxValue / 100];
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = rand.Next(-1000, 1001);
            }

            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();
                
            FilterArrayValuesUsingStrings(testArray, 7);
            TimeSpan stringTime = timer.Elapsed;
            timer.Stop();

            timer.Reset();

            timer.Start();
            FilterArrayValuesUsingDivision(testArray, 7);
            TimeSpan divisionTime = timer.Elapsed;

            timer.Stop();

            Console.WriteLine("String method: " + stringTime);
            Console.WriteLine("Division method: " + divisionTime);
        }