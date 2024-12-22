namespace Tools.SceneLoader
{
    public sealed class NextSceneHandler
    {
        private string _nextSceneName;

        public string GetScene()
        {
            CheckScene();
            
            return _nextSceneName;
        }
        
        private void CheckScene()
        {
            if (_nextSceneName == null)
            {
                _nextSceneName = DataHolder.QuizScene;
            }
        }
    }
}