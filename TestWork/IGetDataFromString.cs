using System.Text;

namespace TestWork
{
    public interface IGetDataFromString
    {
        IGetDataFromString GetDataFromString { get; }
        StringBuilder GetData(string line);
    }
}
