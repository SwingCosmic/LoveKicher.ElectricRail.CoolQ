using LoveKicher.ElectricRail.CoolQ.Constants;

namespace LoveKicher.ElectricRail.CoolQ.Events
{
    public class InitializeEventArgs : PluginEventArgs 
    {

        public int AuthCode { get; }
        public InitializeEventArgs(int authCode)
        {
            AuthCode = authCode;
        }
        
        
    }
}