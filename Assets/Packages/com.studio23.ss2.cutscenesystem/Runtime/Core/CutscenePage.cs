using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Studio23.SS2.Cutscenesystem.Core;
using Studio23.SS2.Cutscenesystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Studio23.SS2.Cutscenesystem.Core
{
    public class CutscenePage : MonoBehaviour
    {
        private List<CutscenePanelData> PanelDatas = new List<CutscenePanelData>();

        [SerializeField] public List<Image> strips;

        public bool PageFull => PanelDatas.Sum(r => r.ColumnSpan) == 3;

        [SerializeField]private int _numberOfStrips;
        [SerializeField] private int currentStripNo = -1;

        public void AddPanel(CutscenePanelData panelData)
        {
            PanelDatas.Add(panelData);
        }

        void Start()
        {
            Initialize();
        }


        public void Initialize()
        {
          
            foreach (Image strip in strips)
            {
                strip.GetComponent<CanvasGroup>().alpha = 0f;
            }

            for (int i = 0; i < PanelDatas.Count; i++)
            {
                strips[i].sprite = PanelDatas[i].ComicSprite;
            }

            _numberOfStrips = strips.Count;

        }


        [ContextMenu("Fade in")]
        public void FadeIn()
        {
            Debug.Log("Faded");
            currentStripNo++;
            if (currentStripNo == _numberOfStrips)
            {
                return;
            }
            var dd = strips[currentStripNo].GetComponent<CanvasGroup>();
            DOTween.To(x => dd.alpha = x, 0, 1f, 1.5f);
        }


        public bool NextStrip()
        {
            currentStripNo++;
            if (currentStripNo == _numberOfStrips)
            {
                return false;
            }
            //fade in
            var dd = strips[currentStripNo].GetComponent<CanvasGroup>();
            DOTween.To(x => dd.alpha = x, 0, 1f, 1.5f);
            return true;
        }

        public void SetVisibility(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}