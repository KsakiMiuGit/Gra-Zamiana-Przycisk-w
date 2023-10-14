
using System.Xml;

namespace Zadanie1;

public partial class WidokGry : ContentPage
{
    private Gra graObj;
    Button[] tablicaPrzyciskow = new Button[9];
    private int selectedRow = -1;
    private int selectedColumn = -1;
    private Button previouslyClickedButton;
    public int[,] GetGameStatus
    {
        get { return graObj.GetGameStatus; }
    }
    public WidokGry()
	{
		InitializeComponent();
        graObj = new Gra();
        CollectButtons();
        OverwriteButtons();
        previouslyClickedButton = null;
    }

    private void button_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;

        if (previouslyClickedButton != null && graObj.GameMovement(previouslyClickedButton, clickedButton))
        {
            int row1 = Grid.GetRow(previouslyClickedButton);
            int col1 = Grid.GetColumn(previouslyClickedButton);
            int row2 = Grid.GetRow(clickedButton);
            int col2 = Grid.GetColumn(clickedButton);

            graObj.Switch(row1, col1, row2, col2);
            OverwriteButtons();
            if (graObj.Win())
            {
               Navigation.PushAsync(new WidokWygranej());
            }
        }

        previouslyClickedButton = clickedButton;

    }

    private void Losuj_Clicked(object sender, EventArgs e)
    {
        graObj.Shuffle();
        OverwriteButtons();
    }
    void CollectButtons()
    {
        tablicaPrzyciskow[0] = button00;
        tablicaPrzyciskow[1] = button01;
        tablicaPrzyciskow[2] = button02;
        tablicaPrzyciskow[3] = button10;
        tablicaPrzyciskow[4] = button11;
        tablicaPrzyciskow[5] = button12;
        tablicaPrzyciskow[6] = button20;
        tablicaPrzyciskow[7] = button21;
        tablicaPrzyciskow[8] = button22;
        
    }
    void OverwriteButtons()
    {
        int[,] tablicaObiektow = graObj.GetGameStatus;
        int indeksTablicyPrzyciskow = 0;
        for(int i = 0;i<tablicaObiektow.GetLength(0);i++) 
        {
            for(int j = 0; j < tablicaObiektow.GetLength(1);j++)
            {
                if (tablicaObiektow[i, j] == 0)
                    tablicaPrzyciskow[indeksTablicyPrzyciskow].Text = String.Empty;
                else
                {
                    tablicaPrzyciskow[indeksTablicyPrzyciskow].Text = tablicaObiektow[i,j].ToString();
                    indeksTablicyPrzyciskow++;
                }
            }
            
        }
    }
}