namespace VENET_Common
{
    using System;

    public partial class WaitForm : DevExpress.XtraWaitForm.WaitForm
    {
        public WaitForm()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = progressPanel1.AutoWidth = true;
            progressPanel1.LookAndFeel.SkinName = MultiForm.SkinName;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);

            WaitFormCommand command = (WaitFormCommand)cmd;
            if (command == WaitFormCommand.SetProgress)
            {
                SetDescription((string)arg);
            }
        }

        #endregion

        public enum WaitFormCommand
        {
            SetProgress,
            //Command2,
            //Command3
        }
    }
}