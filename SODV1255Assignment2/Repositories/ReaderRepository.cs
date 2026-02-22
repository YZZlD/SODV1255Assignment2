using SODV1255Assignment2.Models;

namespace SODV1255Assignment2.Repositories
{
    public class ReaderRepository
    {
        private List<Reader> _readers = new List<Reader>();

        public List<Reader> GetAllReaders()
        {
            return _readers;
        }

        public Reader GetReaderById(int id)
        {
            return _readers[id];
        }

        public Reader AddReader(Reader reader)
        {
            _readers.Add(reader);
            return reader;
        }

        public Reader UpdateReader(string name, int id)
        {
            _readers[id].Name = name;
            return _readers[id];
        }

        public void DeleteReader(int id)
        {
            _readers.RemoveAt(id);
        }
    }


}
