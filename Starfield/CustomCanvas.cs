using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Starfield
{
    public class CustomCanvas : Panel
    {
        private List<DrawingVisual> vObjects;

        public CustomCanvas()
        {
            ClipToBounds = true;
            vObjects = new List<DrawingVisual>();
        }

        public void ClearVisuals()
        {
            foreach (var vObject in vObjects)
            {
                RemoveLogicalChild(vObject);
                RemoveVisualChild(vObject);
            }
            vObjects.Clear();
        }

        public void RemoveVisual(DrawingVisual visualObject)
        {
            vObjects.Remove(visualObject);
            RemoveLogicalChild(visualObject);
            RemoveVisualChild(visualObject);
        }

        public void AddVObject(DrawingVisual visual)
        {
            vObjects.Add(visual);
            AddLogicalChild(visual);
            AddVisualChild(visual);
        }

        protected override int VisualChildrenCount => vObjects.Count;

        protected override Visual GetVisualChild(int index) => vObjects[index];
    }
}
