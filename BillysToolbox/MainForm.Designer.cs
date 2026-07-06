namespace BillysToolbox
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            u8ArchiveToolStripMenuItem = new ToolStripMenuItem();
            particleEffectToolStripMenuItem = new ToolStripMenuItem();
            bREFFToolStripMenuItem = new ToolStripMenuItem();
            bREFTToolStripMenuItem = new ToolStripMenuItem();
            postEffectToolStripMenuItem = new ToolStripMenuItem();
            bLIGHTToolStripMenuItem1 = new ToolStripMenuItem();
            bDOFToolStripMenuItem1 = new ToolStripMenuItem();
            bBLMToolStripMenuItem = new ToolStripMenuItem();
            bFGToolStripMenuItem = new ToolStripMenuItem();
            bLMAPToolStripMenuItem = new ToolStripMenuItem();
            bTIToolStripMenuItem = new ToolStripMenuItem();
            kMPToolStripMenuItem = new ToolStripMenuItem();
            kCLToolStripMenuItem = new ToolStripMenuItem();
            bMMToolStripMenuItem = new ToolStripMenuItem();
            tPLToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip = new MenuStrip();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            nImageScalerToolStripMenuItem = new ToolStripMenuItem();
            magicMinimapToolStripMenuItem = new ToolStripMenuItem();
            windowsToolStripMenuItem = new ToolStripMenuItem();
            makeExternalToolStripMenuItem = new ToolStripMenuItem();
            reattachToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tileToolStripMenuItem = new ToolStripMenuItem();
            verticalToolStripMenuItem = new ToolStripMenuItem();
            horizontalToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            saveToolStripButton = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            openToolStripButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            menuStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator5, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { u8ArchiveToolStripMenuItem, particleEffectToolStripMenuItem, postEffectToolStripMenuItem, kMPToolStripMenuItem, kCLToolStripMenuItem, bMMToolStripMenuItem, tPLToolStripMenuItem });
            newToolStripMenuItem.Image = Properties.Resources.page_white_add;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(123, 22);
            newToolStripMenuItem.Text = "New";
            // 
            // u8ArchiveToolStripMenuItem
            // 
            u8ArchiveToolStripMenuItem.Image = Properties.Resources.szs;
            u8ArchiveToolStripMenuItem.Name = "u8ArchiveToolStripMenuItem";
            u8ArchiveToolStripMenuItem.Size = new Size(146, 22);
            u8ArchiveToolStripMenuItem.Text = "U8 Archive";
            u8ArchiveToolStripMenuItem.Click += u8ArchiveToolStripMenuItem_Click;
            // 
            // particleEffectToolStripMenuItem
            // 
            particleEffectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bREFFToolStripMenuItem, bREFTToolStripMenuItem });
            particleEffectToolStripMenuItem.Image = Properties.Resources.flame;
            particleEffectToolStripMenuItem.Name = "particleEffectToolStripMenuItem";
            particleEffectToolStripMenuItem.Size = new Size(146, 22);
            particleEffectToolStripMenuItem.Text = "Particle Effect";
            // 
            // bREFFToolStripMenuItem
            // 
            bREFFToolStripMenuItem.Image = Properties.Resources.flame;
            bREFFToolStripMenuItem.Name = "bREFFToolStripMenuItem";
            bREFFToolStripMenuItem.Size = new Size(106, 22);
            bREFFToolStripMenuItem.Text = "BREFF";
            bREFFToolStripMenuItem.Click += bREFFToolStripMenuItem_Click;
            // 
            // bREFTToolStripMenuItem
            // 
            bREFTToolStripMenuItem.Image = Properties.Resources.sparkle;
            bREFTToolStripMenuItem.Name = "bREFTToolStripMenuItem";
            bREFTToolStripMenuItem.Size = new Size(106, 22);
            bREFTToolStripMenuItem.Text = "BREFT";
            bREFTToolStripMenuItem.Click += bREFTToolStripMenuItem_Click;
            // 
            // postEffectToolStripMenuItem
            // 
            postEffectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bLIGHTToolStripMenuItem1, bDOFToolStripMenuItem1, bBLMToolStripMenuItem, bFGToolStripMenuItem, bLMAPToolStripMenuItem, bTIToolStripMenuItem });
            postEffectToolStripMenuItem.Image = Properties.Resources.camera;
            postEffectToolStripMenuItem.Name = "postEffectToolStripMenuItem";
            postEffectToolStripMenuItem.Size = new Size(146, 22);
            postEffectToolStripMenuItem.Text = "Post Effect";
            // 
            // bLIGHTToolStripMenuItem1
            // 
            bLIGHTToolStripMenuItem1.Image = Properties.Resources.help;
            bLIGHTToolStripMenuItem1.Name = "bLIGHTToolStripMenuItem1";
            bLIGHTToolStripMenuItem1.Size = new Size(113, 22);
            bLIGHTToolStripMenuItem1.Text = "BLIGHT";
            bLIGHTToolStripMenuItem1.Click += bLIGHTToolStripMenuItem1_Click;
            // 
            // bDOFToolStripMenuItem1
            // 
            bDOFToolStripMenuItem1.Image = Properties.Resources.bdof;
            bDOFToolStripMenuItem1.Name = "bDOFToolStripMenuItem1";
            bDOFToolStripMenuItem1.Size = new Size(113, 22);
            bDOFToolStripMenuItem1.Text = "BDOF";
            bDOFToolStripMenuItem1.Click += bDOFToolStripMenuItem1_Click;
            // 
            // bBLMToolStripMenuItem
            // 
            bBLMToolStripMenuItem.Image = Properties.Resources.bblm;
            bBLMToolStripMenuItem.Name = "bBLMToolStripMenuItem";
            bBLMToolStripMenuItem.Size = new Size(113, 22);
            bBLMToolStripMenuItem.Text = "BBLM";
            bBLMToolStripMenuItem.Click += bBLMToolStripMenuItem_Click;
            // 
            // bFGToolStripMenuItem
            // 
            bFGToolStripMenuItem.Image = Properties.Resources.bfg;
            bFGToolStripMenuItem.Name = "bFGToolStripMenuItem";
            bFGToolStripMenuItem.Size = new Size(113, 22);
            bFGToolStripMenuItem.Text = "BFG";
            bFGToolStripMenuItem.Click += bFGToolStripMenuItem_Click;
            // 
            // bLMAPToolStripMenuItem
            // 
            bLMAPToolStripMenuItem.Enabled = false;
            bLMAPToolStripMenuItem.Image = Properties.Resources.blmap;
            bLMAPToolStripMenuItem.Name = "bLMAPToolStripMenuItem";
            bLMAPToolStripMenuItem.Size = new Size(113, 22);
            bLMAPToolStripMenuItem.Text = "BLMAP";
            // 
            // bTIToolStripMenuItem
            // 
            bTIToolStripMenuItem.Image = Properties.Resources.Decal;
            bTIToolStripMenuItem.Name = "bTIToolStripMenuItem";
            bTIToolStripMenuItem.Size = new Size(113, 22);
            bTIToolStripMenuItem.Text = "BTI";
            bTIToolStripMenuItem.Click += bTIToolStripMenuItem_Click;
            // 
            // kMPToolStripMenuItem
            // 
            kMPToolStripMenuItem.Image = Properties.Resources.kmp;
            kMPToolStripMenuItem.Name = "kMPToolStripMenuItem";
            kMPToolStripMenuItem.Size = new Size(146, 22);
            kMPToolStripMenuItem.Text = "KMP";
            kMPToolStripMenuItem.Click += kMPToolStripMenuItem_Click;
            // 
            // kCLToolStripMenuItem
            // 
            kCLToolStripMenuItem.Image = Properties.Resources.brres;
            kCLToolStripMenuItem.Name = "kCLToolStripMenuItem";
            kCLToolStripMenuItem.Size = new Size(146, 22);
            kCLToolStripMenuItem.Text = "KCL";
            kCLToolStripMenuItem.Click += kCLToolStripMenuItem_Click;
            // 
            // bMMToolStripMenuItem
            // 
            bMMToolStripMenuItem.Image = Properties.Resources.mii;
            bMMToolStripMenuItem.Name = "bMMToolStripMenuItem";
            bMMToolStripMenuItem.Size = new Size(146, 22);
            bMMToolStripMenuItem.Text = "BMM";
            bMMToolStripMenuItem.Click += bMMToolStripMenuItem_Click;
            // 
            // tPLToolStripMenuItem
            // 
            tPLToolStripMenuItem.Image = Properties.Resources.Decal;
            tPLToolStripMenuItem.Name = "tPLToolStripMenuItem";
            tPLToolStripMenuItem.Size = new Size(146, 22);
            tPLToolStripMenuItem.Text = "TPL";
            tPLToolStripMenuItem.Click += tPLToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = Properties.Resources.folder;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(123, 22);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(120, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = Properties.Resources.disk;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(123, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Image = Properties.Resources.save_as;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(123, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImeMode = ImeMode.NoControl;
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, windowsToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1237, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nImageScalerToolStripMenuItem, magicMinimapToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // nImageScalerToolStripMenuItem
            // 
            nImageScalerToolStripMenuItem.Image = Properties.Resources.images;
            nImageScalerToolStripMenuItem.Name = "nImageScalerToolStripMenuItem";
            nImageScalerToolStripMenuItem.Size = new Size(167, 22);
            nImageScalerToolStripMenuItem.Text = "2^N Image Scaler";
            nImageScalerToolStripMenuItem.Click += nImageScalerToolStripMenuItem_Click;
            // 
            // magicMinimapToolStripMenuItem
            // 
            magicMinimapToolStripMenuItem.Image = (Image)resources.GetObject("magicMinimapToolStripMenuItem.Image");
            magicMinimapToolStripMenuItem.Name = "magicMinimapToolStripMenuItem";
            magicMinimapToolStripMenuItem.Size = new Size(167, 22);
            magicMinimapToolStripMenuItem.Text = "Magic Minimap";
            magicMinimapToolStripMenuItem.ToolTipText = "Center-aligns map_model.brres";
            magicMinimapToolStripMenuItem.Click += magicMinimapToolStripMenuItem_Click;
            // 
            // windowsToolStripMenuItem
            // 
            windowsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { makeExternalToolStripMenuItem, reattachToolStripMenuItem, toolStripSeparator3, tileToolStripMenuItem, toolStripMenuItem1, toolStripSeparator1, closeAllToolStripMenuItem });
            windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            windowsToolStripMenuItem.Size = new Size(63, 20);
            windowsToolStripMenuItem.Text = "Window";
            // 
            // makeExternalToolStripMenuItem
            // 
            makeExternalToolStripMenuItem.Image = (Image)resources.GetObject("makeExternalToolStripMenuItem.Image");
            makeExternalToolStripMenuItem.Name = "makeExternalToolStripMenuItem";
            makeExternalToolStripMenuItem.Size = new Size(148, 22);
            makeExternalToolStripMenuItem.Text = "Make External";
            makeExternalToolStripMenuItem.Click += makeExternalToolStripMenuItem_Click;
            // 
            // reattachToolStripMenuItem
            // 
            reattachToolStripMenuItem.Image = (Image)resources.GetObject("reattachToolStripMenuItem.Image");
            reattachToolStripMenuItem.Name = "reattachToolStripMenuItem";
            reattachToolStripMenuItem.Size = new Size(148, 22);
            reattachToolStripMenuItem.Text = "Reattach All";
            reattachToolStripMenuItem.Click += reattachToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(145, 6);
            // 
            // tileToolStripMenuItem
            // 
            tileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verticalToolStripMenuItem, horizontalToolStripMenuItem });
            tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            tileToolStripMenuItem.Size = new Size(148, 22);
            tileToolStripMenuItem.Text = "Tile";
            // 
            // verticalToolStripMenuItem
            // 
            verticalToolStripMenuItem.Image = (Image)resources.GetObject("verticalToolStripMenuItem.Image");
            verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            verticalToolStripMenuItem.Size = new Size(129, 22);
            verticalToolStripMenuItem.Text = "Vertical";
            verticalToolStripMenuItem.Click += verticalToolStripMenuItem_Click;
            // 
            // horizontalToolStripMenuItem
            // 
            horizontalToolStripMenuItem.Image = (Image)resources.GetObject("horizontalToolStripMenuItem.Image");
            horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            horizontalToolStripMenuItem.Size = new Size(129, 22);
            horizontalToolStripMenuItem.Text = "Horizontal";
            horizontalToolStripMenuItem.Click += horizontalToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Image = (Image)resources.GetObject("toolStripMenuItem1.Image");
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(148, 22);
            toolStripMenuItem1.Text = "Cascade";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(145, 6);
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Image = (Image)resources.GetObject("closeAllToolStripMenuItem.Image");
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(148, 22);
            closeAllToolStripMenuItem.Text = "Close All";
            closeAllToolStripMenuItem.Click += closeAllToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem1, helpToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Image = Properties.Resources.help;
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(107, 22);
            aboutToolStripMenuItem1.Text = "About";
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Image = Properties.Resources.kmp;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(107, 22);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { saveToolStripButton, toolStripButton2, openToolStripButton, toolStripSeparator2, toolStripButton1, toolStripButton3, toolStripButton4, toolStripButton7 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1237, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = Properties.Resources.disk;
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(23, 22);
            saveToolStripButton.Text = "Save";
            saveToolStripButton.Click += saveToolStripButton_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = Properties.Resources.save_as;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "Save As...";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = Properties.Resources.folder;
            openToolStripButton.ImageTransparentColor = Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(23, 22);
            openToolStripButton.Text = "Open...";
            openToolStripButton.Click += openToolStripButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "Tile Vertical";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(23, 22);
            toolStripButton3.Text = "Tile Horizontal";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(23, 22);
            toolStripButton4.Text = "Make External";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(23, 22);
            toolStripButton7.Text = "Reattach All";
            toolStripButton7.Click += toolStripButton7_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 687);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "Mario Kart Wii Toolbox";
            Load += MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private MenuStrip menuStrip;
        private ToolStrip toolStrip1;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripMenuItem u8ArchiveToolStripMenuItem;
        private ToolStripMenuItem kCLToolStripMenuItem;
        private ToolStripMenuItem postEffectToolStripMenuItem;
        private ToolStripMenuItem bLIGHTToolStripMenuItem1;
        private ToolStripMenuItem bDOFToolStripMenuItem1;
        private ToolStripMenuItem bBLMToolStripMenuItem;
        private ToolStripMenuItem bFGToolStripMenuItem;
        private ToolStripMenuItem bMMToolStripMenuItem;
        private ToolStripMenuItem kMPToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem nImageScalerToolStripMenuItem;
        private ToolStripMenuItem tPLToolStripMenuItem;
        private ToolStripMenuItem particleEffectToolStripMenuItem;
        private ToolStripMenuItem bREFFToolStripMenuItem;
        private ToolStripMenuItem bREFTToolStripMenuItem;
        private ToolStripMenuItem bLMAPToolStripMenuItem;
        private ToolStripMenuItem bTIToolStripMenuItem;
        private ToolStripMenuItem windowsToolStripMenuItem;
        private ToolStripMenuItem tileToolStripMenuItem;
        private ToolStripMenuItem verticalToolStripMenuItem;
        private ToolStripMenuItem horizontalToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton3;
        private ToolStripMenuItem makeExternalToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem reattachToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem magicMinimapToolStripMenuItem;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton7;
    }
}