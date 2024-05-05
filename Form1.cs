
using Timer = System.Windows.Forms.Timer;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        // 紀錄遊戲中的按鈕數量和圖片數量
        public static int totalImages = 6;
        public static int totalButtons = totalImages*2;

        // 紀錄遊戲中已經配對成功的圖片數量
        private int matchedCount = 0;
        // 紀錄遊戲中的圖片
        private List<Image> gameImages = new List<Image>();

        // 紀錄遊戲中的按鈕
        private List<Button> buttons = new List<Button>();

        // 紀錄使用者點擊的兩個按鈕
        private  MatchingButton firstClickedButton = null;
        private  MatchingButton secondClickedButton = null;
        // 紀錄使用者點擊的按鈕數量
        private int clicksCount = 0;

        // 宣告 Timer 物件
        private  Timer timer = new Timer();

        // 紀錄遊戲開始時間
        private DateTime startTime;
        
        //
        public Form1()
        {
            this.Text = "Image Matching Game";
            this.Size = new Size(640, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += Form1_Load;

            // 載入遊戲圖片, 初始化按鈕
            LoadGameImages();
            InitializeButtons();

            // 設定 timer 的 Tick 事件的處理函式
            timer.Tick += Timer_Tick;
        }
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            // 紀錄遊戲開始時間
            startTime = DateTime.Now; 
        }

        private void LoadGameImages()
        {
            // 手動將圖片加入到 gameImages 列表中
            gameImages.Add(Properties.Resources.Image1);
            gameImages.Add(Properties.Resources.Image2);
            gameImages.Add(Properties.Resources.Image3);
            gameImages.Add(Properties.Resources.Image4);
            gameImages.Add(Properties.Resources.Image5);
            gameImages.Add(Properties.Resources.Image6);
            // TODO 根據需要加入更多圖片

            // 確保 gameImages 中有足夠的圖片供遊戲使用
            if (gameImages.Count < totalImages)
            {
                MessageBox.Show("遊戲圖片不足，請加入更多圖片。");
                this.Close();
            }
           
        }

        // 產生隨機的圖片索引
        public static List<int> GenerateRandomImageIndexes()
        {
            List<int> CardIndexes = new List<int>();
            //
            Random random = new Random();
            //
            for (int i = 0; i < totalImages; i++)
            {
                CardIndexes.Add(i);
                CardIndexes.Add(i);
            }

            List<int> randomIndexes = new List<int>();

            while (CardIndexes.Count > 0)
            {
                int randomIndex = random.Next(CardIndexes.Count);
                randomIndexes.Add(CardIndexes[randomIndex]);
                CardIndexes.RemoveAt(randomIndex);
            }
            //
            return randomIndexes;
        }

        // 初始化遊戲中的按鈕
        private void InitializeButtons()
        {
            // 產生隨機的圖片索引, 並且根據這些索引來初始化按鈕
            List<int> randomIndexes = GenerateRandomImageIndexes();
            // 動態生成按鈕
            for (int i = 0; i < totalButtons; i++)
            {
                // 取得圖片索引
                int cardIndex = randomIndexes[i];
                // TODO: 建立 MatchingButton 物件, 設定按鈕的相關屬性(Tag, Location), 事件處理函式
                Button button = new Button();
                button.Size = new Size(100, 100);
                //
                button.Tag = cardIndex;
                button.Location = new Point((i % 6) * 100 + 10, (i / 6) * 100 + 15);
                this.Controls.Add(button);
                button.Click += MatchingButton_Click;

                // 將按鈕加入到 buttons 列表中
                buttons.Add(button);
                //
            }
        }

        // 按鈕的 Click 事件處理函式
        private void MatchingButton_Click(object sender, EventArgs e)
        {
            // TODO - 修改為 MatchingButton 的判斷方式
            Button btn = sender as Button;
            MessageBox.Show($"Button_CardID:{btn.Tag} Clicked");
        }

        // Timer 的 Tick 事件處理函式: 將[被點的兩個按鈕]的圖片翻轉為背面
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 停止 timer
            timer.Stop();

            // TODO: 將[被點的兩個按鈕]的圖片翻轉為背面


            // Reset firstClickedButton and secondClickedButton
            firstClickedButton = null;
            secondClickedButton = null;
            // Reset clicksCount
            clicksCount = 0;
        }

        // 遊戲完成
        private void GameCompleted()
        {
            // TODO 計算出遊戲完成的秒數
            int elapsedSeconds = 0;
            MessageBox.Show("遊戲完成！使用秒數：" + elapsedSeconds);
            this.Close();
        }
    }
}
