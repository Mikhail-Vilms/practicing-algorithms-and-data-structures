namespace PracticingAlgorithmsAndDataStructures.DynamicProgramming
{
    public class LongestCommonSubsequenceSolution
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int[,] matrix = new int[text2.Length, text1.Length];

            for (int row = 0; row < text2.Length; row++)
            {
                for (int col = 0; col < text1.Length; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        matrix[row, col] = text2[row] == text1[col] ? 1 : 0;
                        continue;
                    }

                    if (row == 0)
                    {
                        matrix[row, col] = text2[row] == text1[col] ? 1 : matrix[row, col - 1];
                        continue;
                    }

                    if (col == 0)
                    {
                        matrix[row, col] = text2[row] == text1[col] ? 1 : matrix[row - 1, col];
                        continue;
                    }

                    if (text2[row] == text1[col])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                        continue;
                    }

                    matrix[row, col] = matrix[row, col - 1] > matrix[row - 1, col] ? matrix[row, col - 1] : matrix[row - 1, col];
                }
            }

            return matrix[text2.Length - 1, text1.Length - 1];
        }
    }
}
