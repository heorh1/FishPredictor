using FishPredictor.DB;
using System.Collections;

namespace FishPredictor
{
    public class FishList : IEnumerable<Fish>
    {
        private List<Fish> _fishes = new List<Fish>();

        public void Add(Fish fish)
        {
            _fishes.Add(fish);
        }

        public IEnumerator<Fish> GetEnumerator()
        {
            return _fishes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
