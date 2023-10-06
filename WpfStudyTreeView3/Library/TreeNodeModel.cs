using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyTreeView3.Properties;

namespace WpfStudyTreeView3.Library
{
    public enum NodeTypes
    {
        Well,
        Rock,
        Polygon,
        WellStrategy,
        WellChild,
        RockChild,
        PolygonChild,
        WellStrategyChild
    }

    public class TreeNodeModel : PropertyChangedBase
    {
        private string name;
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        public string DisplayedImagePath { get; set; }

        public NodeTypes NodeType { get; set; }

        public string ParentName { get; set; }

        public bool IsParentNode { get; set; }

        public ObservableCollection<TreeNodeModel> Items { get; set; }


        public TreeNodeModel(string name, NodeTypes type, string parentName)
        {
            Name = name;
            NodeType = type;
            ParentName = parentName;
            DisplayedImagePath = GetImage(type);
            IsParentNode = !type.ToString().Contains("Child");
            Items = new ObservableCollection<TreeNodeModel>();
        }


        private static string GetImage(NodeTypes type)
        {
            string imagePath = type switch
            {
                NodeTypes.Well => Constants.ImagePath.WellImagePath,
                NodeTypes.Rock => Constants.ImagePath.RockImagePath,
                NodeTypes.Polygon => Constants.ImagePath.PolygonImagePath,
                NodeTypes.WellStrategy => Constants.ImagePath.WellStrategyImagePath,
                NodeTypes.WellChild => Constants.ImagePath.WellChildImagePath,
                NodeTypes.RockChild => Constants.ImagePath.RockChildImagePath,
                NodeTypes.WellStrategyChild => Constants.ImagePath.WellStrategyChildImagePath,
                _ => Constants.ImagePath.DefaultImagePath,
            };
            return imagePath;
        }
    }
}
