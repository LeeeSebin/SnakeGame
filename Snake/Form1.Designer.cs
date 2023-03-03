namespace Snake
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
            #region Windows Form 디자이너에서 생성한 코드

            /// <summary>
            /// 디자이너 지원에 필요한 메서드입니다. 
            /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
            /// </summary>
        private void InitializeComponent()
        {
            /***********************************************************/
            this.boardPanel = new DoubleBufferedPanel();
            /***********************************************************/
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.BackColor = System.Drawing.Color.SeaGreen;
            this.boardPanel.Location = new System.Drawing.Point(12, 12);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(700, 700);
            this.boardPanel.TabIndex = 0;
            this.boardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(757, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "R = Restart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 834);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boardPanel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /***********************************************************/
        private DoubleBufferedPanel boardPanel;
        /***********************************************************/
        private System.Windows.Forms.Label label1;

        /***********************************************************/
        class DoubleBufferedPanel : System.Windows.Forms.Panel
        {
            public DoubleBufferedPanel()
            {
                SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
                SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            }
        }
        /***********************************************************/
    }
}

