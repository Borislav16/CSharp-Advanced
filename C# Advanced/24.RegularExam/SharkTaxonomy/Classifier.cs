using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
                Capacity = capacity;
                Species = new List<Shark>();
        }
        public int Capacity { get; set; }

        public List<Shark> Species { get; set; }

        public int GetCount => Species.Count;

        public void AddShark(Shark shark)
        {
            if (Species.Count < Capacity)
            {
                Shark givenShark = Species.FirstOrDefault(s => s.Kind == shark.Kind);
                if (givenShark == null)
                {
                    Species.Add(shark);
                }
            }
        }

        public bool RemoveShark(string kind)
        {
            Shark givenShark = Species.FirstOrDefault(s => s.Kind == kind);
            if (givenShark == null)
            {
                return false;
            }
            else
            {
                Species.Remove(givenShark);
                return true;
            }
        }

        public string GetLargestShark()
        {
            Shark shark = Species.OrderByDescending(s => s.Length).First();
            return shark.ToString();
        }

        public double GetAverageLength()
        {
            double average = Species.Average(s => s.Length);
            return average;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Species.Count} sharks classified:");
            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
