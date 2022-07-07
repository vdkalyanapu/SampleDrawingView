namespace SampleDrawingApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void SignaturePadView_DrawingLineCompleted(object sender, CommunityToolkit.Maui.Core.DrawingLineCompletedEventArgs e)
    {
        try
        {
            string signaturesDirectoryPath = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "Signatures");

            if(!Directory.Exists(signaturesDirectoryPath))
                Directory.CreateDirectory(signaturesDirectoryPath);

            string filename = System.IO.Path.Combine(signaturesDirectoryPath, "Signature.png");
            using (FileStream outStream = new FileStream(filename, FileMode.Create))
            {
                using (var imageStream = await SignaturePadView.GetImageStream(SignaturePadView.Width, SignaturePadView.Height))
                {
                    imageStream.CopyTo(outStream);
                }
            }
           
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save. "+ ex);
            //need to show a toast
        }
    }
}

