using SiliconWraith.Common.API.Contexts;


namespace SiliconWraith.Common.API.Common
{
    public interface IObjectInialized<TInitializationInput1> where TInitializationInput1 : IContext
    {
        bool IsInitialized { get; }
        void Initialize(TInitializationInput1 input);
    }

    public interface IObjectInialized<TInitializationInput1, TInitializationInput2> where TInitializationInput1 : IContext
                                                                                    where TInitializationInput2 : IContext
    {
        bool IsInitialized { get; }
        void Initialize(TInitializationInput1 input1, TInitializationInput2 wokerSourceConfiguration);
    }
}
