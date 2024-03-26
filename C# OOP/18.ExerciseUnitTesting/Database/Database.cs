using System;

namespace Database
{
    public class Database
    {
        private int[] data;

        private int count;

        public Database(params int[] data)
        {
            this.data = new int[16];
            // Passed Test 2/2
            for (int i = 0; i < data.Length; i++)
            {
                this.Add(data[i]);
            }
            // Passed Test
            this.count = data.Length;
        }
        // Passed Test
        public int Count
        {
            get { return count; }
        }
        //Passed Test 3/3
        public void Add(int element)
        {
            // Passed Test 1/3
            if (this.count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            // Passed Test 1/3      
            this.data[this.count] = element;
            // Passed Test 1/3
            this.count++;
        }

        public void Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }
            //Passed Test 1/3
            this.count--;

            this.data[this.count] = 0;
        }

        public int[] Fetch()
        {
            int[] coppyArray = new int[this.count];

            for (int i = 0; i < this.count; i++)
            {
                coppyArray[i] = this.data[i];
            }

            return coppyArray;
        }
    }
}
