
namespace RobotDreams.CharacterSystem
{
    public interface IPanel
    {
        public void ShowPanel();
        public void ShowPanel(string id);
        public void HidePanel();
        public void HidePanel(string id);
    }
}