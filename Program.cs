// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Func<double, double> myfunc = MultipleByTwo;

var type = myfunc.GetType();
var wrapped = CreateDelegate(myfunc);

Evaluate(myfunc, 3.14);

double MultipleByTwo(double x) => x * 2;


IDelegate<ARG, RET> CreateDelegate<ARG, RET>(Func<ARG, RET> func)
{
    return new FuncDelegate<ARG, RET>(func);
}

void Evaluate<ARG, RET>(IDelegate<ARG,RET> func, ARG x)
{
    Console.WriteLine(func.Invoke(x)); 
}

interface IDelegate<ARG, RET>
{
    RET Invoke(ARG item);
}

class FuncDelegate<ARG, RET> : IDelegate<ARG, RET>
{
    private Func<ARG, RET> func;


    public FuncDelegate(Func<ARG, RET> func)
    {
        this.func = func;
    }

    public RET Invoke(ARG item)
    {
        return func(item);
    }

}
