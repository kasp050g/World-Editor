using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace World_Editor
{
    public class TileActionBarGUI 
    {
        public EditorController editorController;

        private GUI_Image lowerBar;

        private GUI_Button button;
        //public GUI_Button button_sand;

        public List<string> tileButtons = new List<string>();
        public List<string> decorationButtons = new List<string>();
        public List<string> enemySpawnButtons = new List<string>();

        private List<GameObject> tileButtonsGO = new List<GameObject>();
        private List<GameObject> decorationButtonsGO = new List<GameObject>();
        private List<GameObject> enemySpawnButtonsGO = new List<GameObject>();

        private GUI_Button tileButton;
        private GUI_Button decorationButton;
        private GUI_Button enemySpawnButton;


        public void Initialize()
        {
            LowerBar();
            PickTypeButton();

            // Add Tile button's
            tileButtons.Add("grass1");
            tileButtons.Add("grass3");
            tileButtons.Add("sand");
            tileButtons.Add("water1");
            tileButtons.Add("water2");
            TileBar();

            // Add Decoration button's
            decorationButtons.Add("AppleTree");
            decorationButtons.Add("tree_1");
            decorationButtons.Add("tree_2");
            decorationButtons.Add("chest_1");
            DecorationBar();


            EnemySpawnBar();



            HideAll();
            this.ShowList(tileButtonsGO.Cast<GUI>().ToList(), this.tileButton);
        }

        public void PickTypeButton()
        {
            // Tile button
            button = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.sprites["CollisionTexture"],
                ShowGUI = true,
                ButtonScale = new Vector2(150.0f, 40.0f),
                Position = new Vector2(lowerBar.Transform.Position.X + 0, lowerBar.Transform.Position.Y - 190),
                LayerDepth = 0.02f,
                Font = GameWorld.spriteContainer.normalFont,
                Text = "Tile",
                FontScale = new Vector2(0.5f, 0.5f)
                
            };
            button.Click += ShowTileButtons;
            button.Color = Color.Yellow;
            tileButton = button;
            GameWorld.Instatiate(button);

            // Description button
            button = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.sprites["CollisionTexture"],
                ShowGUI = true,
                ButtonScale = new Vector2(150.0f, 40.0f),
                Position = new Vector2(lowerBar.Transform.Position.X + 150, lowerBar.Transform.Position.Y - 190),
                LayerDepth = 0.02f,
                Font = GameWorld.spriteContainer.normalFont,
                Text = "Description",
                FontScale = new Vector2(0.5f, 0.5f)

            };
            button.Click += ShowDecorationButtons;
            button.Color = Color.LightGray;
            decorationButton = button;
            GameWorld.Instatiate(button);

            // EnemySpawn button
            button = new GUI_Button()
            {
                Sprite = GameWorld.spriteContainer.sprites["CollisionTexture"],
                ShowGUI = true,
                ButtonScale = new Vector2(150.0f, 40.0f),
                Position = new Vector2(lowerBar.Transform.Position.X + 300, lowerBar.Transform.Position.Y - 190),
                LayerDepth = 0.02f,
                Font = GameWorld.spriteContainer.normalFont,
                Text = "Enemy Spawn",
                FontScale = new Vector2(0.5f, 0.5f)

            };
            button.Click += EnemySpawnButtons;
            button.Color = Color.LightGray;
            enemySpawnButton = button;
            GameWorld.Instatiate(button);
        }

        public void LowerBar()
        {
            lowerBar = new GUI_Image()
            {
                Sprite = GameWorld.spriteContainer.sprites["CollisionTexture"],
                ShowGUI = true,
                Scale = new Vector2(GameWorld.ScreenSize.X, 1),
                Position = new Vector2(0, GameWorld.ScreenSize.Y - 150),
                OriginEnum = OriginPositionEnum.BottomMid,
                LayerDepth = 0.01f,
                Color = Color.Black,
            };
            GameWorld.Instatiate(lowerBar);
            lowerBar = new GUI_Image()
            {
                Sprite = GameWorld.spriteContainer.sprites["CollisionTexture"],
                ShowGUI = true,
                Scale = new Vector2(GameWorld.ScreenSize.X, 150),
                Position = new Vector2(0, GameWorld.ScreenSize.Y),
                OriginEnum = OriginPositionEnum.BottomMid,
                LayerDepth = 0.01f,
                Color = Color.LightGray,
            };
            GameWorld.Instatiate(lowerBar);
        }

        public void TileBar()
        {
            for (int i = 0; i < tileButtons.Count; i++)
            {
                button = new GUI_Button()
                {
                    Sprite = GameWorld.spriteContainer.sprites[tileButtons[i]],
                    ShowGUI = true,
                    ButtonScale = new Vector2(100f / (float)GameWorld.spriteContainer.sprites[tileButtons[i]].Width, 100f / (float)GameWorld.spriteContainer.sprites[tileButtons[i]].Width),
                    Position = new Vector2(lowerBar.Transform.Position.X + 25 +(i * 125), lowerBar.Transform.Position.Y - 125),
                    LayerDepth = 0.02f,
                    spriteName  = this.tileButtons[i],
                    
                };
                button.Click += CallTileSprite;
                tileButtonsGO.Add(button);
                GameWorld.Instatiate(button);
            }
        }

        public void DecorationBar()
        {
            for (int i = 0; i < decorationButtons.Count; i++)
            {
                button = new GUI_Button()
                {
                    Sprite = GameWorld.spriteContainer.sprites[decorationButtons[i]],
                    ShowGUI = true,
                    ButtonScale = new Vector2(100f / (float)GameWorld.spriteContainer.sprites[decorationButtons[i]].Width, 100f / (float)GameWorld.spriteContainer.sprites[decorationButtons[i]].Height),
                    Position = new Vector2(lowerBar.Transform.Position.X + 25 + (i * 125), lowerBar.Transform.Position.Y - 125),
                    LayerDepth = 0.02f,
                    spriteName = this.decorationButtons[i],

                };
                button.Click += CallTileSprite;
                decorationButtonsGO.Add(button);
                GameWorld.Instatiate(button);
            }
        }

        public void EnemySpawnBar()
        {
            for (int i = 0; i < enemySpawnButtons.Count; i++)
            {
                button = new GUI_Button()
                {
                    Sprite = GameWorld.spriteContainer.sprites[enemySpawnButtons[i]],
                    ShowGUI = true,
                    ButtonScale = new Vector2(0.25f, 0.25f),
                    Position = new Vector2(lowerBar.Transform.Position.X + 25 + (i * 125), lowerBar.Transform.Position.Y - 125),
                    LayerDepth = 0.02f,
                    spriteName = this.enemySpawnButtons[i],

                };
                button.Click += CallTileSprite;
                enemySpawnButtonsGO.Add(button);
                GameWorld.Instatiate(button);
            }
        }

        private void CallTileSprite(object sender, System.EventArgs e)
        {
            var loadSpriteName = ((SeleteTileEvent)e).spriteName;
            GameWorld.editor.tileController.CurrentSprite = GameWorld.spriteContainer.sprites[loadSpriteName];
        }

        public void HideAll()
        {
            foreach (var x in tileButtonsGO)
            {
                (x as GUI).ShowGUI = false;
            }
            foreach (var x in decorationButtonsGO)
            {
                (x as GUI).ShowGUI = false;
            }
            foreach (var x in enemySpawnButtonsGO)
            {
                (x as GUI).ShowGUI = false;
            }
            tileButton.Color = Color.LightGray;
            decorationButton.Color = Color.LightGray;
            enemySpawnButton.Color = Color.LightGray;
        }

        public void ShowTileButtons(object sender, System.EventArgs e)
        {
            HideAll();
            editorController.CurrentSelectedTileType = SelectedTileType.Tile;
            this.ShowList(tileButtonsGO.Cast<GUI>().ToList(), this.tileButton);
        }

        public void ShowDecorationButtons(object sender, System.EventArgs e)
        {
            HideAll();
            editorController.CurrentSelectedTileType = SelectedTileType.Decoration;
            this.ShowList(decorationButtonsGO.Cast<GUI>().ToList(), this.decorationButton);
        }

        public void EnemySpawnButtons(object sender, System.EventArgs e)
        {
            HideAll();
            editorController.CurrentSelectedTileType = SelectedTileType.EnemySpawn;
            this.ShowList(enemySpawnButtonsGO.Cast<GUI>().ToList() , this.enemySpawnButton) ;
        }

        public void ShowList(List<GUI> gos, GUI_Button button)
        {
            foreach (var go in gos)
            {
                go.ShowGUI = true;
            }
            button.Color = Color.Yellow;
        }
    }
}
