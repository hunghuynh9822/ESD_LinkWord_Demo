using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class LineEmptyBoxAnswer
    {
        private int index;
        private List<Box> boxes;
        private int count;
        private bool isChecked;

        public LineEmptyBoxAnswer(int index, List<Box> boxes)
        {
            this.index = index;
            this.boxes = boxes;
            this.count = boxes.Count;
            this.isChecked = false;
        }

        //public bool compareNumberChar(int count)
        //{
        //    return this.count == count;
        //}

        public List<Box> getGameObjects()
        {
            return this.boxes;
        }

        public bool getChecked()
        {
            return isChecked;
        }

        public void setChecked(bool state)
        {
            this.isChecked = state;
        }
    }
}
