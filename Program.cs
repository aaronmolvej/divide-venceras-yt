using System;

namespace DivideYVencerasConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMOSTRACIÓN DE ALGORITMOS: DIVIDE Y VENCERÁS ===\n");

            // 1. Ejemplo de Merge Sort
            Console.WriteLine("--- 1. Ordenamiento por Mezcla (Merge Sort) ---");
            int[] arrMerge = { 38, 27, 43, 3, 9, 82, 10 };
            Console.WriteLine("Arreglo original: " + string.Join(", ", arrMerge));
            MergeSortAlgorithm.MergeSort(arrMerge, 0, arrMerge.Length - 1);
            Console.WriteLine("Arreglo ordenado: " + string.Join(", ", arrMerge) + "\n");

            // 2. Ejemplo de Quick Sort
            Console.WriteLine("--- 2. Ordenamiento Rápido (Quick Sort) ---");
            int[] arrQuick = { 10, 7, 8, 9, 1, 5 };
            Console.WriteLine("Arreglo original: " + string.Join(", ", arrQuick));
            QuickSortAlgorithm.QuickSort(arrQuick, 0, arrQuick.Length - 1);
            Console.WriteLine("Arreglo ordenado: " + string.Join(", ", arrQuick) + "\n");

            // 3. Ejemplo de Búsqueda Binaria
            Console.WriteLine("--- 3. Búsqueda Binaria Recursiva ---");
            int[] arrSearch = { 2, 3, 4, 10, 40, 55, 89 }; // Debe estar ordenado
            int target1 = 10;
            int target2 = 5;
            Console.WriteLine("Arreglo donde buscar: " + string.Join(", ", arrSearch));

            int result1 = BinarySearchAlgorithm.BinarySearch(arrSearch, 0, arrSearch.Length - 1, target1);
            Console.WriteLine($"Buscando el {target1}: " + (result1 != -1 ? $"Encontrado en el índice {result1}" : "No encontrado"));

            int result2 = BinarySearchAlgorithm.BinarySearch(arrSearch, 0, arrSearch.Length - 1, target2);
            Console.WriteLine($"Buscando el {target2}: " + (result2 != -1 ? $"Encontrado en el índice {result2}" : "No encontrado") + "\n");

            // 4. Ejemplo de Exponenciación Rápida
            Console.WriteLine("--- 4. Exponenciación Rápida ---");
            long baseNum = 2;
            int exponente = 10;
            long resultadoPotencia = FastExponentiation.Power(baseNum, exponente);
            Console.WriteLine($"Calculando {baseNum}^{exponente} = {resultadoPotencia}");
            Console.WriteLine($"Calculando 3^5 = {FastExponentiation.Power(3, 5)}\n");

            // 5. Ejemplo de Máximo y Mínimo
            Console.WriteLine("--- 5. Encontrar Máximo y Mínimo Simultáneamente ---");
            int[] arrMinMax = { 1000, 11, 445, 1, 330, 3000 };
            Console.WriteLine("Arreglo: " + string.Join(", ", arrMinMax));
            var (min, max) = MaxMinAlgorithm.FindMaxMin(arrMinMax, 0, arrMinMax.Length - 1);
            Console.WriteLine($"El valor mínimo es: {min}");
            Console.WriteLine($"El valor máximo es: {max}\n");

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }


    public class MergeSortAlgorithm
    {
        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, mid + 1, R, 0, n2);

            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j]) arr[k++] = L[i++];
                else arr[k++] = R[j++];
            }

            while (i < n1) arr[k++] = L[i++];
            while (j < n2) arr[k++] = R[j++];
        }
    }

    public class QuickSortAlgorithm
    {
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
    }

    public class BinarySearchAlgorithm
    {
        public static int BinarySearch(int[] arr, int left, int right, int x)
        {
            if (right >= left)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == x) return mid;
                if (arr[mid] > x) return BinarySearch(arr, left, mid - 1, x);

                return BinarySearch(arr, mid + 1, right, x);
            }
            return -1;
        }
    }

    public class FastExponentiation
    {
        public static long Power(long x, int y)
        {
            if (y == 0) return 1;

            long temp = Power(x, y / 2);

            if (y % 2 == 0)
                return temp * temp;
            else
                return x * temp * temp;
        }
    }

    public class MaxMinAlgorithm
    {
        public static (int min, int max) FindMaxMin(int[] arr, int left, int right)
        {
            if (left == right)
                return (arr[left], arr[left]);

            if (right == left + 1)
            {
                if (arr[left] < arr[right])
                    return (arr[left], arr[right]);
                else
                    return (arr[right], arr[left]);
            }

            int mid = left + (right - left) / 2;
            var leftResult = FindMaxMin(arr, left, mid);
            var rightResult = FindMaxMin(arr, mid + 1, right);

            int finalMin = Math.Min(leftResult.min, rightResult.min);
            int finalMax = Math.Max(leftResult.max, rightResult.max);

            return (finalMin, finalMax);
        }
    }
}