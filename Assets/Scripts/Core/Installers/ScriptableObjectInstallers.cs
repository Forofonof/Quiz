using System.Collections.Generic;
using Core.Cell;
using Core.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public sealed class ScriptableObjectInstallers : MonoInstaller
    {
        [Header("Cell (Scriptable Object)")]
        [SerializeField] private List<CellSO> _cells;
        [Header("Difficulty Quiz (Scriptable Object)")]
        [SerializeField] private QuizRoundSettingSO _quizRoundSetting;
        
        public override void InstallBindings()
        {
            Container.Bind<List<CellSO>>().FromInstance(_cells).AsSingle();
            Container.Bind<QuizRoundSettingSO>().FromInstance(_quizRoundSetting).AsSingle();
        }
    }
}