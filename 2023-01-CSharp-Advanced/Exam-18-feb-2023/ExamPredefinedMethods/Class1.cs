namespace ExamPredefinedMethods
{
    public static class Class1
    {

        // Create square matrix with given size
        public static char[][] CreateField(int size)
        {
            char[][] field = new char[size][];
            for (int row = 0; row < size; row++)
            {
                field[row] = new char[size];
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    if (!char.IsWhiteSpace(input[col]))
                    {
                        field[row][col] = input[col];
                    }
                }
            }
            return field;
        }
        
        // Print given matrix
        private static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }


    }
}