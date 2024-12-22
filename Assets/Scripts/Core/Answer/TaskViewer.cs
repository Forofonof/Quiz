using TMPro;
using Zenject;

namespace Core.Answer
{
    public sealed class TaskViewer
    {
        private readonly TaskViewerAnimation _animation = new TaskViewerAnimation();
        
        [Inject(Id = "_labelText")] private TMP_Text _labelText;
        [Inject] private ResponsesHandler _responsesHandler;

        public void Initialize()
        {
            _responsesHandler.OnNewTaskGenerated += ShowNewTask;
        }

        private void ShowNewTask(string task)
        {
            _labelText.text = "Find: " + task;
            _animation.StartFadeIn(_labelText);
        }
    }
}