using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sakkagya
{
 class agy
        {


            public static bool Dangerous_Square;

            public static int[,] Chessboard_Dangerous_Squares = new int[8, 8];
            public static int[,] Number_of_defend = new int[8, 8];
            public static int[,] Number_of_attack = new int[8, 8];

            public static int[,] Value_of_defend = new int[8, 8];
            public static int[,] Value_of_attack = new int[8, 8];



            public static bool possibility_back;


            public static int Value_of_human_moving_piece = 0;
            public static int Value_of_System_moving_piece = 0;


            public static int Temp_Score_Move_0;
            public static int Temp_Score_Move_1_human;
            public static int Temp_Score_Move_2;

            public static int[,] NodesAnalysis0 = new int[1000000, 6];
            public static int[,] NodesAnalysis1 = new int[1000000, 2];
            public static int[,] NodesAnalysis2 = new int[1000000, 2];
            public static int[,] NodesAnalysis3 = new int[1000000, 2];
            public static int[,] NodesAnalysis4 = new int[1000000, 2];


            public static int NodeLevel_0_count;
            public static int NodeLevel_1_count;
            public static int NodeLevel_2_count;
            public static int NodeLevel_3_count;
            public static int NodeLevel_4_count;

            public static int Human_last_move_target_column;
            public static int Human_last_move_target_row;


            public static String[,] Chess_board = new String[8, 8];

            public static String m_PlayerColor;

            public static int m_WhoPlays;
            public static String m_WhichColorPlays;
            public static String MovingPiece;


            public static String Temporary_piece;
            public static String ProsorinoKommati_KingCheck;


            public static bool exit_legim_check = false;
            public static int h;
            public static int p;
            public static int how_to_move_Rank;
            public static int how_to_move_Column;

            public static bool King_check = false;


            public static String m_StartingColumn;
            public static int m_StartingRank;
            public static String m_FinishingColumn;
            public static int m_FinishingRank;


            public static bool enpassant_occured;


            public static int Move;



            public static bool Promotion_Occured = false;


            public static bool Castling_Occured = false;




            public static int WhiteKingColumn;
            public static int WhiteKingRank;
            public static int BlKingColumn;
            public static int BlKingRank;


            public static bool WhiteKingCheck;
            public static bool BlackKingCheck;


            public static bool Finde_the_best_move;


            public static bool Danger_from_right;
            public static bool Danger_from_left;
            public static bool Danger_from_up;
            public static bool Danger_from_down;
            public static bool Danger_from_up_right;
            public static bool Danger_from_down_right;
            public static bool Danger_from_up_left;
            public static bool Danger_from_down_left;


            public static int Starting_white_king_column;
            public static int Starting_white_king_rank;
            public static int Starting_black_king_column;
            public static int Starting_black_king_rank;


            public static int m_StartingColumnNumber;
            public static int m_FinishingColumnNumber;


            public static bool Right_move;

            public static bool legitimal_beh;

            public static bool m_WrongColumn;


            public static int i;
            public static int j;


            public static int User_decision = 1;
            public static int choise_of_user;


            public static String[,] Chessboard_Move_0 = new String[8, 8];
            public static String[,] Chessboard_Move_After = new String[8, 8];
            public static String[,] Chessboard_Thinking = new String[8, 8];
            public static String[,] Chessboard_CM_Check = new String[8, 8];

            public static int Current_Move_Score;
            public static int Best_Move_StartingColumnNumber;
            public static int Best_Move_FinishingColumnNumber;
            public static int Best_Move_StartingRank;
            public static int Best_Move_FinishingRank;
            public static int Move_Analyzed;
            public static bool Stop_Analyzing;
            public static int Thinking_Depth;
            public static int StartingColumnNumber;
            public static int FinishingColumnNumber;
            public static int x_StartingRank;
            public static int x_FinishingRank;
            public static bool First_Call;
            public static String Who_Is_Analyzed;
            public static String x_MovingPiece;


            public static String x_Starting_Column_Text;
            public static String x_Finishing_Column_Text;




            public static int enpassant_possible_target_rank;
            public static int enpassant_possible_target_column;


            static void Main(string[] args)
            {

                Console.Write("Color (w/b)? ");
                String the_choise_of_user = Console.ReadLine();


                if (the_choise_of_user.CompareTo("w") == 0)
                {

                    m_PlayerColor = "Wh";

                    m_WhoPlays = 1;
                }
                else if (the_choise_of_user.CompareTo("b") == 0)
                {
                    m_PlayerColor = "Bl";

                    m_WhoPlays = 0;
                }


                Thinking_Depth = 2;





                Move = 0;
                m_WhichColorPlays = "Wh";


                Starting_position();



                bool exit_game = false;

                do
                {


                    if (m_WhoPlays == 0)
                    {


                        Move_Analyzed = 0;
                        Stop_Analyzing = false;
                        First_Call = true;
                        Finde_the_best_move = false;
                        Who_Is_Analyzed = "HY";


                        #region checkDanger


                        for (i = 0; i <= 7; i++)
                        {
                            for (j = 0; j <= 7; j++)
                            {

                                Chessboard_Dangerous_Squares[i, j] = 0;
                            }
                        }


                        for (int q = 0; q <= 7; q++)
                        {
                            for (int w = 0; w <= 7; w++)
                            {
                                Number_of_attack[q, w] = 0;
                                Number_of_defend[q, w] = 0;
                                Value_of_attack[q, w] = 0;

                                Value_of_defend[q, w] = 0;

                            }
                        }

                        FindAttackers(Chess_board);
                        FindDefenders(Chess_board);

                        #endregion checkDanger



                        ComputerMove(Chess_board);
                    }

                    else if (m_WhoPlays == 1)
                    {

                        Console.WriteLine("");
                        Console.Write("Start column:");
                        m_StartingColumn = Console.ReadLine().ToUpper();

                        Console.Write("Start rank:");
                        m_StartingRank = Int32.Parse(Console.ReadLine());

                        Console.Write("End column:");
                        m_FinishingColumn = Console.ReadLine().ToUpper();

                        Console.Write("End rank:");
                        m_FinishingRank = Int32.Parse(Console.ReadLine());


                        Console.WriteLine(String.Concat("Your move: ", m_StartingColumn, m_StartingRank.ToString(), " -> ", m_FinishingColumn, m_FinishingRank.ToString()));


                        Enter_move();
                    }

                } while (exit_game == false);

            }


            public static bool CheckForBlackCheck(string[,] c_chessboard)
            {


                bool KingCheck;



                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {

                        if (c_chessboard[(i), (j)].CompareTo("BK") == 0)
                        {
                            BlKingColumn = (i + 1);
                            BlKingRank = (j + 1);
                        }

                    }
                }



                KingCheck = false;



                Danger_from_right = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((BlKingColumn + dv) <= 8) && (Danger_from_right == true))
                    {
                        if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("WR") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("WQ") == 0))

                        KingCheck = true;

                        else if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("BP") == 0) || 
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("BR") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("BN") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("BB") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("BQ") == 0))
                            Danger_from_right = false;
                        else if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("WP") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("WN") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("WB") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - 1)].CompareTo("WK") == 0))
                            Danger_from_right = false;
                    }
                }





                Danger_from_left = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((BlKingColumn - dv) >= 1) && (Danger_from_left == true))
                    {
                        if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("WR") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("WQ") == 0))
                            KingCheck = true;
                        else if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("BP") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("BR") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("BN") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("BB") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("BQ") == 0))
                            Danger_from_left = false;
                        else if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("WP") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("WN") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("WB") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - 1)].CompareTo("WK") == 0))
                            Danger_from_left = false;
                    }
                }





                Danger_from_up = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((BlKingRank + dv) <= 8) && (Danger_from_up == true))
                    {
                        if ((c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("WR") == 0) || 
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("WQ") == 0))
                            KingCheck = true;
                        else if ((c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("BP") == 0) || 
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("BR") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("BN") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("BB") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("BQ") == 0))

                        Danger_from_up = false;

                        else if ((c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("WP") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("WN") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("WB") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank + dv - 1)].CompareTo("WK") == 0))
                            Danger_from_up = false;
                    }
                }





                Danger_from_down = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((BlKingRank - dv) >= 1) && (Danger_from_down == true))
                    {
                        if ((c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("WR") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("WQ") == 0))
                            KingCheck = true;
                        else if ((c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("BP") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("BR") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("BN") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("BB") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("BQ") == 0))
                            Danger_from_down = false;
                        else if ((c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("WP") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("WN") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("WB") == 0) ||
                        (c_chessboard[(BlKingColumn - 1), (BlKingRank - dv - 1)].CompareTo("WK") == 0))
                            Danger_from_down = false;
                    }
                }





                Danger_from_up_right = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((BlKingColumn + dv) <= 8) && ((BlKingRank + dv) <= 8) && (Danger_from_up_right == true))
                    {
                        if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("WB") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("WQ") == 0))
                            KingCheck = true;
                        else if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("BP") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("BR") == 0) || 
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("BN") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("BB") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("BQ") == 0))
                            Danger_from_up_right = false;
                        else if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("WP") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("WR") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("WN") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank + dv - 1)].CompareTo("WK") == 0))
                            Danger_from_up_right = false;
                    }
                }


                Danger_from_down_left = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((BlKingColumn - dv) >= 1) && ((BlKingRank - dv) >= 1) && (Danger_from_down_left == true))
                    {
                        if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("WB") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("WQ") == 0))
                            KingCheck = true;
                        else if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("BP") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("BR") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("BN") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("BB") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("BQ") == 0))
                            Danger_from_down_left = false;
                        else if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("WP") == 0) || 
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("WR") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("WN") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank - dv - 1)].CompareTo("WK") == 0))
                            Danger_from_down_left = false;
                    }
                }

                Danger_from_down_right = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((BlKingColumn + dv) <= 8) && ((BlKingRank - dv) >= 1) && (Danger_from_down_right == true))
                    {
                        if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("WB") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("WQ") == 0))
                            KingCheck = true;
                        else if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("BP") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("BR") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("BN") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("BB") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("BQ") == 0))
                            Danger_from_down_right = false;
                        else if ((c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("WP") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("WR") == 0) || 
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("WN") == 0) ||
                        (c_chessboard[(BlKingColumn + dv - 1), (BlKingRank - dv - 1)].CompareTo("WK") == 0))
                            Danger_from_down_right = false;
                    }
                }


                Danger_from_up_left = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((BlKingColumn - dv) >= 1) && ((BlKingRank + dv) <= 8) && (Danger_from_up_left == true))
                    {
                        if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("WB") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("WQ") == 0))
                            KingCheck = true;
                        else if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("BP") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("BR") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("BN") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("BB") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("BQ") == 0))
                            Danger_from_up_left = false;
                        else if ((c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("WP") == 0) ||
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("WR") == 0) || 
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("WN") == 0) || 
                        (c_chessboard[(BlKingColumn - dv - 1), (BlKingRank + dv - 1)].CompareTo("WK") == 0))
                            Danger_from_up_left = false;
                    }
                }



                if (((BlKingColumn + 1) <= 8) && ((BlKingRank - 1) >= 1))
                {
                    if (c_chessboard[(BlKingColumn + 1 - 1), (BlKingRank - 1 - 1)].CompareTo("WP") == 0)
                    {
                        KingCheck = true;
                    }
                }


                if (((BlKingColumn - 1) >= 1) && ((BlKingRank - 1) >= 1))
                {
                    if (c_chessboard[(BlKingColumn - 1 - 1), (BlKingRank - 1 - 1)].CompareTo("WP") == 0)
                    {
                        KingCheck = true;
                    }
                }


                if (((BlKingColumn + 1) <= 8) && ((BlKingRank + 2) <= 8))
                    if (c_chessboard[(BlKingColumn + 1 - 1), (BlKingRank + 2 - 1)].CompareTo("WN") == 0)
                        KingCheck = true;

                if (((BlKingColumn + 2) <= 8) && ((BlKingRank - 1) >= 1))
                    if (c_chessboard[(BlKingColumn + 2 - 1), (BlKingRank - 1 - 1)].CompareTo("WN") == 0)
                        KingCheck = true;

                if (((BlKingColumn + 1) <= 8) && ((BlKingRank - 2) >= 1))
                    if (c_chessboard[(BlKingColumn + 1 - 1), (BlKingRank - 2 - 1)].CompareTo("WN") == 0)
                        KingCheck = true;

                if (((BlKingColumn - 1) >= 1) && ((BlKingRank - 2) >= 1))
                    if (c_chessboard[(BlKingColumn - 1 - 1), (BlKingRank - 2 - 1)].CompareTo("WN") == 0)
                        KingCheck = true;

                if (((BlKingColumn - 2) >= 1) && ((BlKingRank - 1) >= 1))
                    if (c_chessboard[(BlKingColumn - 2 - 1), (BlKingRank - 1 - 1)].CompareTo("WN") == 0)
                        KingCheck = true;

                if (((BlKingColumn - 2) >= 1) && ((BlKingRank + 1) <= 8))
                    if (c_chessboard[(BlKingColumn - 2 - 1), (BlKingRank + 1 - 1)].CompareTo("WN") == 0)
                        KingCheck = true;

                if (((BlKingColumn - 1) >= 1) && ((BlKingRank + 2) <= 8))
                    if (c_chessboard[(BlKingColumn - 1 - 1), (BlKingRank + 2 - 1)].CompareTo("WN") == 0)
                        KingCheck = true;

                if (((BlKingColumn + 2) <= 8) && ((BlKingRank + 1) <= 8))
                    if (c_chessboard[(BlKingColumn + 2 - 1), (BlKingRank + 1 - 1)].CompareTo("WN") == 0)
                        KingCheck = true;

                return KingCheck;
            }

            public static bool CheckForBlackMate(string[,] Bm_chessboard)
            {


                bool Mate;



                bool DangerForMate;


                Mate = false;
                DangerForMate = true;

                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {

                        if (Bm_chessboard[(i), (j)].CompareTo("BK") == 0)
                        {
                            Starting_black_king_column = (i + 1);
                            Starting_black_king_rank = (j + 1);
                        }

                    }
                }





                if (m_WhichColorPlays.CompareTo("Bl") == 0)
                {



                    BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                    if (BlackKingCheck == false)
                        if (Starting_black_king_rank < 8)
                        {
                            MovingPiece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)];
                            Temporary_piece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1 + 1)];

                            if ((Temporary_piece.CompareTo("BQ") == 1) &&
                            (Temporary_piece.CompareTo("BR") == 1) && 
                            (Temporary_piece.CompareTo("BN") == 1) && 
                            (Temporary_piece.CompareTo("BB") == 1) && 
                            (Temporary_piece.CompareTo("BP") == 1) &&
                            (DangerForMate == true) &&
                            ((Starting_black_king_rank - 1 + 1) <= 7))
                            {


                                Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = "";
                                Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1 + 1)] = MovingPiece;
                                BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                                if (BlackKingCheck == false)
                                    DangerForMate = false;



                                Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                                Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1 + 1)] = Temporary_piece;

                            }

                        }




                    if ((Starting_black_king_column < 8) && (Starting_black_king_rank < 8))
                    {

                        MovingPiece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)];
                        Temporary_piece = Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1 + 1)];

                        if ((Temporary_piece.CompareTo("BQ") == 1) &&
                        (Temporary_piece.CompareTo("BR") == 1) && 
                        (Temporary_piece.CompareTo("BN") == 1) &&
                        (Temporary_piece.CompareTo("BB") == 1) &&
                        (Temporary_piece.CompareTo("BP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_black_king_rank - 1 + 1) <= 7) &&
                        ((Starting_black_king_column - 1 + 1) <= 7))
                        {



                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = "";
                            Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1 + 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                            if (BlackKingCheck == false)
                                DangerForMate = false;


                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1 + 1)] = Temporary_piece;

                        }

                    }



                    if (Starting_black_king_column < 8)
                    {

                        MovingPiece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)];
                        Temporary_piece = Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1)];

                        if ((Temporary_piece.CompareTo("BQ") == 1) && 
                        (Temporary_piece.CompareTo("BR") == 1) &&
                        (Temporary_piece.CompareTo("BN") == 1) && 
                        (Temporary_piece.CompareTo("BB") == 1) && 
                        (Temporary_piece.CompareTo("BP") == 1) && 
                        (DangerForMate == true) &&
                        ((Starting_black_king_column - 1 + 1) <= 7))
                        {


                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = "";
                            Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                            if (BlackKingCheck == false)
                                DangerForMate = false;



                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1)] = Temporary_piece;

                        }

                    }




                    if ((Starting_black_king_column < 8) && (Starting_black_king_rank > 1))
                    {

                        MovingPiece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)];
                        Temporary_piece = Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1 - 1)];

                        if ((Temporary_piece.CompareTo("BQ") == 1) &&
                        (Temporary_piece.CompareTo("BR") == 1) &&
                        (Temporary_piece.CompareTo("BN") == 1) &&
                        (Temporary_piece.CompareTo("BB") == 1) &&
                        (Temporary_piece.CompareTo("BP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_black_king_rank - 1 - 1) >= 0) &&
                        ((Starting_black_king_column - 1 + 1) <= 7))
                        {



                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = "";
                            Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1 - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                            if (BlackKingCheck == false)
                                DangerForMate = false;

                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            Bm_chessboard[(Starting_black_king_column - 1 + 1), (Starting_black_king_rank - 1 - 1)] = Temporary_piece;

                        }

                    }




                    if (Starting_black_king_rank > 1)
                    {

                        MovingPiece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)];
                        Temporary_piece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1 - 1)];

                        if ((Temporary_piece.CompareTo("BQ") == 1) && 
                        (Temporary_piece.CompareTo("BR") == 1) &&
                        (Temporary_piece.CompareTo("BN") == 1) &&
                        (Temporary_piece.CompareTo("BB") == 1) &&
                        (Temporary_piece.CompareTo("BP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_black_king_rank - 1 - 1) >= 0))
                        {



                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = "";
                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1 - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                            if (BlackKingCheck == false)
                                DangerForMate = false;



                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1 - 1)] = Temporary_piece;

                        }

                    }




                    if ((Starting_black_king_column > 1) && (Starting_black_king_rank > 1))
                    {

                        MovingPiece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)];
                        Temporary_piece = Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1 - 1)];

                        if ((Temporary_piece.CompareTo("BQ") == 1) &&
                        (Temporary_piece.CompareTo("BR") == 1) &&
                        (Temporary_piece.CompareTo("BN") == 1) &&
                        (Temporary_piece.CompareTo("BB") == 1) &&
                        (Temporary_piece.CompareTo("BP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_black_king_rank - 1 - 1) >= 0) &&
                        ((Starting_black_king_column - 1 - 1) >= 0))
                        {


                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = "";
                            Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1 - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                            if (BlackKingCheck == false)
                                DangerForMate = false;


                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1 - 1)] = Temporary_piece;

                        }

                    }



                    if (Starting_black_king_column > 1)
                    {

                        MovingPiece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)];
                        Temporary_piece = Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1)];

                        if ((Temporary_piece.CompareTo("BQ") == 1) &&
                        (Temporary_piece.CompareTo("BR") == 1) &&
                        (Temporary_piece.CompareTo("BN") == 1) &&
                        (Temporary_piece.CompareTo("BB") == 1) && 
                        (Temporary_piece.CompareTo("BP") == 1) && 
                        (DangerForMate == true) &&
                        ((Starting_black_king_column - 1 - 1) >= 0))
                        {



                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = "";
                            Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                            if (BlackKingCheck == false)
                                DangerForMate = false;



                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1)] = Temporary_piece;

                        }

                    }




                    if ((Starting_black_king_column > 1) && (Starting_black_king_rank < 8))
                    {

                        MovingPiece = Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)];
                        Temporary_piece = Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1 + 1)];

                        if ((Temporary_piece.CompareTo("BQ") == 1) &&
                        (Temporary_piece.CompareTo("BR") == 1) && 
                        (Temporary_piece.CompareTo("BN") == 1) &&
                        (Temporary_piece.CompareTo("BB") == 1) && 
                        (Temporary_piece.CompareTo("BP") == 1) &&
                        (DangerForMate == true) && 
                        ((Starting_black_king_rank - 1 + 1) <= 7) &&
                        ((Starting_black_king_column - 1 - 1) >= 0))
                        {


                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = "";
                            Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1 + 1)] = MovingPiece;
                            BlackKingCheck = CheckForBlackCheck(Bm_chessboard);

                            if (BlackKingCheck == false)
                                DangerForMate = false;


                            Bm_chessboard[(Starting_black_king_column - 1), (Starting_black_king_rank - 1)] = MovingPiece;
                            Bm_chessboard[(Starting_black_king_column - 1 - 1), (Starting_black_king_rank - 1 + 1)] = Temporary_piece;

                        }

                    }

                    if (DangerForMate == true)
                        Mate = true;

                }

                return Mate;
            }

            public static bool CheckForWhiteCheck(string[,] WC_chessboard)
            {


                bool KingCheck;



                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {

                        if (WC_chessboard[(i), (j)].CompareTo("WK") == 0)
                        {
                            WhiteKingColumn = (i + 1);
                            WhiteKingRank = (j + 1);
                        }

                    }
                }



                KingCheck = false;



                Danger_from_right = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((WhiteKingColumn + dv) <= 8) && (Danger_from_right == true))
                    {
                        if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("BR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("BQ") == 0))
                            KingCheck = true;
                        else if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("WP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("WR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("WN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("WB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("WQ") == 0))
                            Danger_from_right = false;
                        else if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("BP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("BN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("BB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - 1)].CompareTo("BK") == 0))
                            Danger_from_right = false;
                    }
                }




                Danger_from_left = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((WhiteKingColumn - dv) >= 1) && (Danger_from_left == true))
                    {
                        if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("BR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("BQ") == 0))
                            KingCheck = true;
                        else if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("WP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("WR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("WN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("WB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("WQ") == 0))
                            Danger_from_left = false;
                        else if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("BP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("BN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("BB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - 1)].CompareTo("BK") == 0))
                            Danger_from_left = false;
                    }
                }





                Danger_from_up = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((WhiteKingRank + dv) <= 8) && (Danger_from_up == true))
                    {
                        if ((WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("BR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("BQ") == 0))
                            KingCheck = true;
                        else if ((WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("WP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("WR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("WN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("WB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("WQ") == 0))
                            Danger_from_up = false;
                        else if ((WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("BP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("BN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("BB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank + dv - 1)].CompareTo("BK") == 0))
                            Danger_from_up = false;
                    }
                }




                Danger_from_down = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((WhiteKingRank - dv) >= 1) && (Danger_from_down == true))
                    {
                        if ((WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("BR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("BQ") == 0))
                            KingCheck = true;
                        else if ((WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("WP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("WR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("WN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("WB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("WQ") == 0))
                            Danger_from_down = false;
                        else if ((WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("BP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("BN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("BB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - 1), (WhiteKingRank - dv - 1)].CompareTo("BK") == 0))
                            Danger_from_down = false;
                    }
                }




                Danger_from_up_right = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((WhiteKingColumn + dv) <= 8) && ((WhiteKingRank + dv) <= 8) && (Danger_from_up_right == true))
                    {
                        if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BQ") == 0))
                            KingCheck = true;
                        else if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WQ") == 0))
                            Danger_from_up_right = false;
                        else if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BR") == 0) || 
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BK") == 0))
                            Danger_from_up_right = false;
                    }
                }




                Danger_from_down_left = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((WhiteKingColumn - dv) >= 1) && ((WhiteKingRank - dv) >= 1) && (Danger_from_down_left == true))
                    {
                        if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BQ") == 0))
                            KingCheck = true;
                        else if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WQ") == 0))
                            Danger_from_down_left = false;
                        else if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BN") == 0) || 
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BK") == 0))
                            Danger_from_down_left = false;
                    }
                }



                Danger_from_down_right = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((WhiteKingColumn + dv) <= 8) && ((WhiteKingRank - dv) >= 1) && (Danger_from_down_right == true))
                    {
                        if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BQ") == 0))
                            KingCheck = true;
                        else if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WR") == 0) || 
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("WQ") == 0))
                            Danger_from_down_right = false;
                        else if ((WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn + dv - 1), (WhiteKingRank - dv - 1)].CompareTo("BK") == 0))
                            Danger_from_down_right = false;
                    }
                }




                Danger_from_up_left = true;

                for (int dv = 1; dv <= 7; dv++)
                {
                    if (((WhiteKingColumn - dv) >= 1) && ((WhiteKingRank + dv) <= 8) && (Danger_from_up_left == true))
                    {
                        if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BB") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BQ") == 0))
                            KingCheck = true;
                        else if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WB") == 0) || 
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("WQ") == 0))
                            Danger_from_up_left = false;
                        else if ((WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BP") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BR") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BN") == 0) ||
                        (WC_chessboard[(WhiteKingColumn - dv - 1), (WhiteKingRank + dv - 1)].CompareTo("BK") == 0))
                            Danger_from_up_left = false;
                    }
                }





                if (((WhiteKingColumn + 1) <= 8) && ((WhiteKingRank + 1) <= 8))
                {
                    if (WC_chessboard[(WhiteKingColumn + 1 - 1), (WhiteKingRank + 1 - 1)].CompareTo("BP") == 0)
                    {
                        KingCheck = true;
                    }
                }


                if (((WhiteKingColumn - 1) >= 1) && ((WhiteKingRank + 1) <= 8))
                {
                    if (WC_chessboard[(WhiteKingColumn - 1 - 1), (WhiteKingRank + 1 - 1)].CompareTo("BP") == 0)
                    {
                        KingCheck = true;
                    }
                }




                if (((WhiteKingColumn + 1) <= 8) && ((WhiteKingRank + 2) <= 8))
                    if (WC_chessboard[(WhiteKingColumn + 1 - 1), (WhiteKingRank + 2 - 1)].CompareTo("BN") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn + 2) <= 8) && ((WhiteKingRank - 1) >= 1))
                    if (WC_chessboard[(WhiteKingColumn + 2 - 1), (WhiteKingRank - 1 - 1)].CompareTo("BN") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn + 1) <= 8) && ((WhiteKingRank - 2) >= 1))
                    if (WC_chessboard[(WhiteKingColumn + 1 - 1), (WhiteKingRank - 2 - 1)].CompareTo("BN") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn - 1) >= 1) && ((WhiteKingRank - 2) >= 1))
                    if (WC_chessboard[(WhiteKingColumn - 1 - 1), (WhiteKingRank - 2 - 1)].CompareTo("BN") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn - 2) >= 1) && ((WhiteKingRank - 1) >= 1))
                    if (WC_chessboard[(WhiteKingColumn - 2 - 1), (WhiteKingRank - 1 - 1)].CompareTo("BN") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn - 2) >= 1) && ((WhiteKingRank + 1) <= 8))
                    if (WC_chessboard[(WhiteKingColumn - 2 - 1), (WhiteKingRank + 1 - 1)].CompareTo("BN") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn - 1) >= 1) && ((WhiteKingRank + 2) <= 8))
                    if (WC_chessboard[(WhiteKingColumn - 1 - 1), (WhiteKingRank + 2 - 1)].CompareTo("BN") == 0)
                        KingCheck = true;

                if (((WhiteKingColumn + 2) <= 8) && ((WhiteKingRank + 1) <= 8))
                    if (WC_chessboard[(WhiteKingColumn + 2 - 1), (WhiteKingRank + 1 - 1)].CompareTo("BN") == 0)
                        KingCheck = true;

                return KingCheck;
            }

            public static bool CheckForWhiteMate(string[,] WM_chessboard)
            {


                bool Mate;

                bool DangerForMate;


                Mate = false;
                DangerForMate = true;
                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {

                        if (WM_chessboard[(i), (j)].CompareTo("WK") == 0)
                        {
                            Starting_white_king_column = (i + 1);
                            Starting_white_king_rank = (j + 1);
                        }

                    }
                }



                if (m_WhichColorPlays.CompareTo("Wh") == 0)
                {


                    WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                    if (WhiteKingCheck == false)
                        if (Starting_white_king_rank < 8)
                        {

                            MovingPiece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)];
                            Temporary_piece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1 + 1)];

                            if ((Temporary_piece.CompareTo("WQ") == 1) && 
                            (Temporary_piece.CompareTo("WR") == 1) && 
                            (Temporary_piece.CompareTo("WN") == 1) && 
                            (Temporary_piece.CompareTo("WB") == 1) &&
                            (Temporary_piece.CompareTo("WP") == 1) &&
                            (DangerForMate == true) &&
                            ((Starting_white_king_rank - 1 + 1) <= 7))
                            {



                                WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = "";
                                WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1 + 1)] = MovingPiece;
                                WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                                if (WhiteKingCheck == false)
                                    DangerForMate = false;



                                WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                                WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1 + 1)] = Temporary_piece;

                            }

                        }




                    if ((Starting_white_king_column < 8) && (Starting_white_king_rank < 8))
                    {

                        MovingPiece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)];
                        Temporary_piece = WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1 + 1)];

                        if ((Temporary_piece.CompareTo("WQ") == 1) &&
                        (Temporary_piece.CompareTo("WR") == 1) &&
                        (Temporary_piece.CompareTo("WN") == 1) && 
                        (Temporary_piece.CompareTo("WB") == 1) && 
                        (Temporary_piece.CompareTo("WP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_white_king_rank - 1 + 1) <= 7) &&
                        ((Starting_white_king_column - 1 + 1) <= 7))
                        {



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = "";
                            WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1 + 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;


                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1 + 1)] = Temporary_piece;

                        }

                    }




                    if (Starting_white_king_column < 8)
                    {

                        MovingPiece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)];
                        Temporary_piece = WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1)];

                        if ((Temporary_piece.CompareTo("WQ") == 1) &&
                        (Temporary_piece.CompareTo("WR") == 1) &&
                        (Temporary_piece.CompareTo("WN") == 1) &&
                        (Temporary_piece.CompareTo("WB") == 1) &&
                        (Temporary_piece.CompareTo("WP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_white_king_column - 1 + 1) <= 7))
                        {



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = "";
                            WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1)] = Temporary_piece;

                        }

                    }




                    if ((Starting_white_king_column < 8) && (Starting_white_king_rank > 1))
                    {

                        MovingPiece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)];
                        Temporary_piece = WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1 - 1)];

                        if ((Temporary_piece.CompareTo("WQ") == 1) &&
                        (Temporary_piece.CompareTo("WR") == 1) && 
                        (Temporary_piece.CompareTo("WN") == 1) && 
                        (Temporary_piece.CompareTo("WB") == 1) &&
                        (Temporary_piece.CompareTo("WP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_white_king_rank - 1 - 1) >= 0) &&
                        ((Starting_white_king_column - 1 + 1) <= 7))
                        {



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = "";
                            WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1 - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WM_chessboard[(Starting_white_king_column - 1 + 1), (Starting_white_king_rank - 1 - 1)] = Temporary_piece;

                        }

                    }




                    if (Starting_white_king_rank > 1)
                    {

                        MovingPiece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)];
                        Temporary_piece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1 - 1)];

                        if ((Temporary_piece.CompareTo("WQ") == 1) &&
                        (Temporary_piece.CompareTo("WR") == 1) && 
                        (Temporary_piece.CompareTo("WN") == 1) && 
                        (Temporary_piece.CompareTo("WB") == 1) && 
                        (Temporary_piece.CompareTo("WP") == 1) && 
                        (DangerForMate == true) &&
                        ((Starting_white_king_rank - 1 - 1) >= 0))
                        {



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = "";
                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1 - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1 - 1)] = Temporary_piece;

                        }

                    }



                    if ((Starting_white_king_column > 1) && (Starting_white_king_rank > 1))
                    {

                        MovingPiece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)];
                        Temporary_piece = WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1 - 1)];

                        if ((Temporary_piece.CompareTo("WQ") == 1) &&
                        (Temporary_piece.CompareTo("WR") == 1) && 
                        (Temporary_piece.CompareTo("WN") == 1) &&
                        (Temporary_piece.CompareTo("WB") == 1) &&
                        (Temporary_piece.CompareTo("WP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_white_king_rank - 1 - 1) >= 0) &&
                        ((Starting_white_king_column - 1 - 1) >= 0))
                        {


                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = "";
                            WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1 - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1 - 1)] = Temporary_piece;

                        }

                    }



                    if (Starting_white_king_column > 1)
                    {

                        MovingPiece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)];
                        Temporary_piece = WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1)];

                        if ((Temporary_piece.CompareTo("WQ") == 1) &&
                        (Temporary_piece.CompareTo("WR") == 1) && 
                        (Temporary_piece.CompareTo("WN") == 1) && 
                        (Temporary_piece.CompareTo("WB") == 1) &&
                        (Temporary_piece.CompareTo("WP") == 1) && 
                        (DangerForMate == true) &&
                        ((Starting_white_king_column - 1 - 1) >= 0))
                        {


                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = "";
                            WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1)] = Temporary_piece;

                        }

                    }


                    if ((Starting_white_king_column > 1) && (Starting_white_king_rank < 8))
                    {

                        MovingPiece = WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)];
                        Temporary_piece = WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1 + 1)];

                        if ((Temporary_piece.CompareTo("WQ") == 1) &&
                        (Temporary_piece.CompareTo("WR") == 1) && 
                        (Temporary_piece.CompareTo("WN") == 1) && 
                        (Temporary_piece.CompareTo("WB") == 1) &&
                        (Temporary_piece.CompareTo("WP") == 1) &&
                        (DangerForMate == true) &&
                        ((Starting_white_king_rank - 1 + 1) <= 7) &&
                        ((Starting_white_king_column - 1 - 1) >= 0))
                        {



                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = "";
                            WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1 + 1)] = MovingPiece;
                            WhiteKingCheck = CheckForWhiteCheck(WM_chessboard);

                            if (WhiteKingCheck == false)
                                DangerForMate = false;

                            WM_chessboard[(Starting_white_king_column - 1), (Starting_white_king_rank - 1)] = MovingPiece;
                            WM_chessboard[(Starting_white_king_column - 1 - 1), (Starting_white_king_rank - 1 + 1)] = Temporary_piece;

                        }

                    }

                    if (DangerForMate == true)
                        Mate = true;

                }

                return Mate;
            }


            public static void CheckMove(string[,] CM_chessboard, int m_StartingRankCM, int m_StartingColumnNumberCM, int m_FinishingRankCM, int m_FinishingColumnNumberCM, String MovingPieceCM)
            {

                String Temporary_piece_CM;

                for (int iii = 0; iii <= 7; iii++)
                {
                    for (int jjj = 0; jjj <= 7; jjj++)
                    {
                        Chessboard_CM_Check[iii, jjj] = CM_chessboard[(iii), (jjj)];
                    }
                }



                m_WhoPlays = 1;
                m_WrongColumn = false;


                Right_move = correct_check(CM_chessboard, 0, m_StartingRankCM, m_StartingColumnNumberCM, m_FinishingRankCM, m_FinishingColumnNumberCM, MovingPieceCM);

                if (Right_move == true)
                    legitimal_beh = legality(CM_chessboard, 0, m_StartingRankCM, m_StartingColumnNumberCM, m_FinishingRankCM, m_FinishingColumnNumberCM, MovingPieceCM);


                m_WhoPlays = 0;
                #region CheckCheck

                Chessboard_CM_Check[(m_StartingColumnNumberCM - 1), (m_StartingRankCM - 1)] = "";
                Temporary_piece_CM = Chessboard_CM_Check[(m_FinishingColumnNumberCM - 1), (m_FinishingRankCM - 1)];

                Chessboard_CM_Check[(m_FinishingColumnNumberCM - 1), (m_FinishingRankCM - 1)] = MovingPieceCM;


                WhiteKingCheck = CheckForWhiteCheck(CM_chessboard);

                if ((m_WhichColorPlays.CompareTo("White") == 0) && (WhiteKingCheck == true))
                {
                    legitimal_beh = false;
                }


                BlackKingCheck = CheckForBlackCheck(CM_chessboard);

                if ((m_WhichColorPlays.CompareTo("Black") == 0) && (BlackKingCheck == true))
                {
                    legitimal_beh = false;
                }


                #endregion CheckCheck

                if (((Right_move == true) && (legitimal_beh == true)) && (Move_Analyzed == 0))
                {

                    x_MovingPiece = MovingPiece;
                    StartingColumnNumber = m_StartingColumnNumber;
                    FinishingColumnNumber = m_FinishingColumnNumber;
                    x_StartingRank = m_StartingRank;
                    x_FinishingRank = m_FinishingRank;


                    NodesAnalysis0[NodeLevel_0_count, 2] = StartingColumnNumber;
                    NodesAnalysis0[NodeLevel_0_count, 3] = FinishingColumnNumber;
                    NodesAnalysis0[NodeLevel_0_count, 4] = x_StartingRank;
                    NodesAnalysis0[NodeLevel_0_count, 5] = x_FinishingRank;


                }

            }



            public static void ComputerMove(string[,] Chessboard_Thinking_init)
            {


                int iii;
                int jjj;
                String MovingPiece0;
                String ProsorinoKommati0;
                int m_StartingColumnNumber0;
                int m_FinishingColumnNumber0;
                int m_StartingRank0;
                int m_FinishingRank0;

                possibility_back = false;

                #region InitializeNodes

                NodeLevel_0_count = 0;
                NodeLevel_1_count = 0;
                NodeLevel_2_count = 0;
                NodeLevel_3_count = 0;
                NodeLevel_4_count = 0;


                for (int dimension1 = 0; dimension1 < 1000000; dimension1++)
                {
                    for (int dimension2 = 0; dimension2 < 6; dimension2++)
                    {
                        NodesAnalysis0[dimension1, dimension2] = 0;
                    }
                }

                for (int dimension1 = 0; dimension1 < 1000000; dimension1++)
                {
                    for (int dimension2 = 0; dimension2 < 2; dimension2++)
                    {
                        NodesAnalysis1[dimension1, dimension2] = 0;
                        NodesAnalysis2[dimension1, dimension2] = 0;
                        NodesAnalysis3[dimension1, dimension2] = 0;
                        NodesAnalysis4[dimension1, dimension2] = 0;

                }
                }
                #endregion InitializeNodes

                #region StoreInitialPosition

                for (iii = 0; iii <= 7; iii++)
                {
                    for (jjj = 0; jjj <= 7; jjj++)
                    {
                        Chessboard_Thinking[iii, jjj] = Chessboard_Thinking_init[(iii), (jjj)];
                        Chessboard_Move_0[(iii), (jjj)] = Chessboard_Thinking_init[(iii), (jjj)];
                    }
                }
                #endregion StoreInitialPosition


                #region DangerousSquares
                Dangerous_Square = false;

                for (int o1 = 0; o1 <= 7; o1++)
                {
                    for (int p1 = 0; p1 <= 7; p1++)
                    {

                        Chessboard_Dangerous_Squares[(o1), (p1)] = 0;
                    }
                }


                FindAttackers(Chessboard_Thinking);
                FindDefenders(Chessboard_Thinking);


                for (int o1 = 0; o1 <= 7; o1++)
                {
                    for (int p1 = 0; p1 <= 7; p1++)
                    {
                        if (Number_of_attack[o1, p1] > Number_of_defend[o1, p1])

                            Chessboard_Dangerous_Squares[(o1), (p1)] = 1;
                    }
                }

                #endregion DangerousSquares


                for (iii = 0; iii <= 7; iii++)
                {
                    for (jjj = 0; jjj <= 7; jjj++)
                    {
                        if (((Who_Is_Analyzed.CompareTo("HY") == 0) && ((((Chessboard_Thinking[(iii),
                            (jjj)].CompareTo("WK") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WQ") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WR") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WN") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WB") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WP") == 0)) && 
                            (m_PlayerColor.CompareTo("Bl") == 0)) ||
                            (((Chessboard_Thinking[(iii), (jjj)].CompareTo("BK") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BQ") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BR") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BN") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BB") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BP") == 0)) &&
                            (m_PlayerColor.CompareTo("Wh") == 0)))) ||
                            ((Who_Is_Analyzed.CompareTo("Hu") == 0) && 
                            ((((Chessboard_Thinking[(iii), (jjj)].CompareTo("WK") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WQ") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WR") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WN") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WB") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("WP") == 0)) &&
                            (m_PlayerColor.CompareTo("Wh") == 0)) ||
                            (((Chessboard_Thinking[(iii), (jjj)].CompareTo("BK") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BQ") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BR") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BN") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BB") == 0) ||
                            (Chessboard_Thinking[(iii), (jjj)].CompareTo("BP") == 0)) && 
                            (m_PlayerColor.CompareTo("Bl") == 0)))))
                        {

                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {

                                    MovingPiece = Chessboard_Thinking[(iii), (jjj)];
                                    m_StartingColumnNumber = iii + 1;
                                    m_FinishingColumnNumber = w + 1;
                                    m_StartingRank = jjj + 1;
                                    m_FinishingRank = r + 1;


                                    MovingPiece0 = MovingPiece;
                                    m_StartingColumnNumber0 = m_StartingColumnNumber;
                                    m_FinishingColumnNumber0 = m_FinishingColumnNumber;
                                    m_StartingRank0 = m_StartingRank;
                                    m_FinishingRank0 = m_FinishingRank;
                                    ProsorinoKommati0 = Chessboard_Thinking[(m_FinishingColumnNumber0 - 1), (m_FinishingRank0 - 1)];

                                    String DoNotMakeStupidMove = "N";
                                    #region CheckStupidMove
                                    if (Move < 5)
                                    {
                                        if ((MovingPiece.CompareTo("WQ") == 0) || (MovingPiece.CompareTo("BQ") == 0) ||
                                                (MovingPiece.CompareTo("WR") == 0) || (MovingPiece.CompareTo("BR") == 0))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if (((MovingPiece.CompareTo("WN") == 0) || (MovingPiece.CompareTo("BN") == 0))
                                                && (m_FinishingColumnNumber == 1))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if (((MovingPiece.CompareTo("WN") == 0) || (MovingPiece.CompareTo("BN") == 0))
                                                && (m_FinishingColumnNumber == 8))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("WN") == 0) && (m_FinishingRank == 2) && (m_FinishingColumnNumber == 4)
                                                && (Chessboard_Thinking[(2), (0)].CompareTo("WB") == 0))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("WN") == 0) && (m_FinishingRank == 2) && (m_FinishingColumnNumber == 5)
                                                && (Chessboard_Thinking[(5), (0)].CompareTo("WB") == 0))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("BN") == 0) && (m_FinishingRank == 7) && (m_FinishingColumnNumber == 4)
                                                && (Chessboard_Thinking[(2), (7)].CompareTo("BB") == 0))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("BN") == 0) && (m_FinishingRank == 7) && (m_FinishingColumnNumber == 5)
                                                && (Chessboard_Thinking[(5), (7)].CompareTo("BB") == 0))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("WP") == 0) && ((m_StartingColumnNumber == 1) || (m_StartingColumnNumber == 2)))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("WP") == 0) && ((m_StartingColumnNumber == 7) || (m_StartingColumnNumber == 8)))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("BP") == 0) && ((m_StartingColumnNumber == 1) || (m_StartingColumnNumber == 2)))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("BP") == 0) && ((m_StartingColumnNumber == 7) || (m_StartingColumnNumber == 8)))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if ((MovingPiece.CompareTo("WK") == 0) || (MovingPiece.CompareTo("BK") == 0))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                        else if (((MovingPiece.CompareTo("WB") == 0) || (MovingPiece.CompareTo("BB") == 0))
                                            && ((m_FinishingRank == 3) || (m_FinishingRank == 5) || (m_FinishingRank == 6)))
                                        {
                                            DoNotMakeStupidMove = "Y";
                                        }
                                    }
                                    #endregion CheckStupidMove



                                    if ((MovingPiece.CompareTo("WR") == 0) || (MovingPiece.CompareTo("BR") == 0))
                                        Value_of_System_moving_piece = 5;
                                    if ((MovingPiece.CompareTo("WN") == 0) || (MovingPiece.CompareTo("BN") == 0))
                                        Value_of_System_moving_piece = 3;
                                    if ((MovingPiece.CompareTo("WB") == 0) || (MovingPiece.CompareTo("BB") == 0))
                                        Value_of_System_moving_piece = 3;
                                    if ((MovingPiece.CompareTo("WQ") == 0) || (MovingPiece.CompareTo("BQ") == 0))
                                        Value_of_System_moving_piece = 9;
                                    if ((MovingPiece.CompareTo("WK") == 0) || (MovingPiece.CompareTo("BK") == 0))
                                        Value_of_System_moving_piece = 119;
                                    if ((MovingPiece.CompareTo("WP") == 0) || (MovingPiece.CompareTo("BP") == 0))
                                        Value_of_System_moving_piece = 1;


                                    if ((Number_of_attack[w, r] == 1) && (Value_of_attack[w, r] < Value_of_System_moving_piece))
                                        DoNotMakeStupidMove = "Y";



                                    if ((DoNotMakeStupidMove.CompareTo("N") == 0) && (Chessboard_Dangerous_Squares[w, r] == 0))
                                    {

                                        CheckMove(Chessboard_Thinking, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);



                                        if ((Right_move == true) && (legitimal_beh == true))
                                        {

                                            Temporary_piece = Chessboard_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                            Chessboard_Thinking[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                            Chessboard_Thinking[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;


                                            if (Move_Analyzed == 0)
                                            {
                                                NodeLevel_0_count++;
                                            
                                                Temp_Score_Move_0 = CountScore(Chessboard_Thinking);
                                            }




                                            if ((m_FinishingColumnNumber == Human_last_move_target_column)
                                                 && (m_FinishingRank == Human_last_move_target_row)
                                                 && (Value_of_System_moving_piece <= Value_of_human_moving_piece))
                                            {
                                                Best_Move_StartingColumnNumber = m_StartingColumnNumber;
                                                Best_Move_StartingRank = m_StartingRank;
                                                Best_Move_FinishingColumnNumber = m_FinishingColumnNumber;
                                                Best_Move_FinishingRank = m_FinishingRank;

                                                possibility_back = true;
                                            }



                                            if ((Move_Analyzed < Thinking_Depth) && (possibility_back == false))
                                            {
                                                Move_Analyzed = Move_Analyzed + 1;


                                                for (i = 0; i <= 7; i++)
                                                {
                                                    for (j = 0; j <= 7; j++)
                                                    {
                                                        Chessboard_Move_After[(i), (j)] = Chessboard_Thinking[(i), (j)];
                                                    }
                                                }


                                                Who_Is_Analyzed = "Hu";

                                                Analyze_Move_1_HumanMove(Chessboard_Move_After);
                                            }


                                            Chessboard_Thinking[(m_StartingColumnNumber0 - 1), (m_StartingRank0 - 1)] = MovingPiece0;
                                            Chessboard_Thinking[(m_FinishingColumnNumber0 - 1), (m_FinishingRank0 - 1)] = ProsorinoKommati0;
                                        }

                                    }


                                }
                            }

                        }


                    }
                }


                if (((WhiteKingCheck == true) || (BlackKingCheck == true)) && (Finde_the_best_move == false))
                {
                    Console.WriteLine("Checkmate!");
                }

                if (possibility_back == false)
                {

                    int counter0, counter1, counter2 , counter3;


                    int parentNodeAnalyzed = -999;

                    for (counter3 = 1; counter3 <=NodeLevel_3_count; counter3++)
                    {
                    if (Int32.Parse(NodesAnalysis3[counter3, 1].ToString()) != parentNodeAnalyzed)
                    {

                        parentNodeAnalyzed = Int32.Parse(NodesAnalysis3[counter3, 1].ToString());
                        NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0] = NodesAnalysis3[counter3, 0];
                    }

                    if (NodesAnalysis3[counter3, 0] >= NodesAnalysis1[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0])
                        NodesAnalysis2[Int32.Parse(NodesAnalysis3[counter3, 1].ToString()), 0] = NodesAnalysis3[counter3, 0];
                    }


                    for (counter2 = 1; counter2 <= NodeLevel_2_count; counter2++)
                    {
                        if (Int32.Parse(NodesAnalysis2[counter2, 1].ToString()) != parentNodeAnalyzed)
                        {

                            parentNodeAnalyzed = Int32.Parse(NodesAnalysis2[counter2, 1].ToString());
                            NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0] = NodesAnalysis2[counter2, 0];
                        }

                        if (NodesAnalysis2[counter2, 0] >= NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0])
                            NodesAnalysis1[Int32.Parse(NodesAnalysis2[counter2, 1].ToString()), 0] = NodesAnalysis2[counter2, 0];
                    }


                    parentNodeAnalyzed = -999;

                    for (counter1 = 1; counter1 <= NodeLevel_1_count; counter1++)
                    {
                        if (Int32.Parse(NodesAnalysis1[counter1, 1].ToString()) != parentNodeAnalyzed)
                        {

                            parentNodeAnalyzed = Int32.Parse(NodesAnalysis1[counter1, 1].ToString());
                            NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0] = NodesAnalysis1[counter1, 0];
                        }

                        if (NodesAnalysis1[counter1, 0] <= NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0])
                            NodesAnalysis0[Int32.Parse(NodesAnalysis1[counter1, 1].ToString()), 0] = NodesAnalysis1[counter1, 0];
                    }

                    double temp_score = NodesAnalysis0[1, 0];
                    Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis0[1, 2].ToString());
                    Best_Move_StartingRank = Int32.Parse(NodesAnalysis0[1, 4].ToString());
                    Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis0[1, 3].ToString());
                    Best_Move_FinishingRank = Int32.Parse(NodesAnalysis0[1, 5].ToString());

                    for (counter0 = 1; counter0 <= NodeLevel_0_count; counter0++)
                    {
                        if (NodesAnalysis0[counter0, 0] > temp_score)
                        {
                            temp_score = NodesAnalysis0[counter0, 0];

                            Best_Move_StartingColumnNumber = Int32.Parse(NodesAnalysis0[counter0, 2].ToString());
                            Best_Move_StartingRank = Int32.Parse(NodesAnalysis0[counter0, 4].ToString());
                            Best_Move_FinishingColumnNumber = Int32.Parse(NodesAnalysis0[counter0, 3].ToString());
                            Best_Move_FinishingRank = Int32.Parse(NodesAnalysis0[counter0, 5].ToString());
                        }
                    }

                }


                if (Best_Move_StartingColumnNumber > 0)
                {
                    MovingPiece = Chess_board[(Best_Move_StartingColumnNumber - 1), (Best_Move_StartingRank - 1)];
                    Chess_board[(Best_Move_StartingColumnNumber - 1), (Best_Move_StartingRank - 1)] = "";

                    if (Best_Move_StartingColumnNumber == 1)
                        x_Starting_Column_Text = "a";
                    else if (Best_Move_StartingColumnNumber == 2)
                        x_Starting_Column_Text = "b";
                    else if (Best_Move_StartingColumnNumber == 3)
                        x_Starting_Column_Text = "c";
                    else if (Best_Move_StartingColumnNumber == 4)
                        x_Starting_Column_Text = "d";
                    else if (Best_Move_StartingColumnNumber == 5)
                        x_Starting_Column_Text = "e";
                    else if (Best_Move_StartingColumnNumber == 6)
                        x_Starting_Column_Text = "f";
                    else if (Best_Move_StartingColumnNumber == 7)
                        x_Starting_Column_Text = "g";
                    else if (Best_Move_StartingColumnNumber == 8)
                        x_Starting_Column_Text = "h";



                    Chess_board[(Best_Move_FinishingColumnNumber - 1), (Best_Move_FinishingRank - 1)] = MovingPiece;

                    if (Best_Move_FinishingColumnNumber == 1)
                        x_Finishing_Column_Text = "a";
                    else if (Best_Move_FinishingColumnNumber == 2)
                        x_Finishing_Column_Text = "b";
                    else if (Best_Move_FinishingColumnNumber == 3)
                        x_Finishing_Column_Text = "c";
                    else if (Best_Move_FinishingColumnNumber == 4)
                        x_Finishing_Column_Text = "d";
                    else if (Best_Move_FinishingColumnNumber == 5)
                        x_Finishing_Column_Text = "e";
                    else if (Best_Move_FinishingColumnNumber == 6)
                        x_Finishing_Column_Text = "f";
                    else if (Best_Move_FinishingColumnNumber == 7)
                        x_Finishing_Column_Text = "g";
                    else if (Best_Move_FinishingColumnNumber == 8)
                        x_Finishing_Column_Text = "h";


                    if ((MovingPiece.CompareTo("WP") == 0) || (MovingPiece.CompareTo("BP") == 0))
                    {
                        if (Best_Move_FinishingRank == 8)
                        {
                            Chess_board[(Best_Move_FinishingColumnNumber - 1), (Best_Move_FinishingRank - 1)] = "WQ";
                            Console.WriteLine("Queen!");
                        }
                        else if (Best_Move_FinishingRank == 1)
                        {
                            Chess_board[(Best_Move_FinishingColumnNumber - 1), (Best_Move_FinishingRank - 1)] = "BQ";
                            Console.WriteLine("Queen!");
                        }
                    }


                    Console.WriteLine(String.Concat("My move: ", x_Starting_Column_Text, Best_Move_StartingRank.ToString(), " -> ", x_Finishing_Column_Text, Best_Move_FinishingRank.ToString()));

                    if (m_PlayerColor.CompareTo("Bl") == 0)
                    {
                        m_WhichColorPlays = "Bl";
                        Move = Move + 1;
                    }
                    else if (m_PlayerColor.CompareTo("Wh") == 0)
                        m_WhichColorPlays = "Wh";


                    m_WhoPlays = 1;
                }

                else
                {

                    Console.WriteLine("I resign!");
                }
            }


            public static int CountScore(string[,] CSS_chessboard)
            {


                Current_Move_Score = 0;

                for (i = 0; i <= 7; i++)
                {
                    for (j = 0; j <= 7; j++)
                    {
                        if (CSS_chessboard[(i), (j)].CompareTo("WP") == 0)
                            Current_Move_Score = Current_Move_Score + 1;
                        else if (CSS_chessboard[(i), (j)].CompareTo("WR") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 5;
                        }
                        else if (CSS_chessboard[(i), (j)].CompareTo("WN") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 3;
                        }
                        else if (CSS_chessboard[(i), (j)].CompareTo("WB") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 3;
                        }
                        else if (CSS_chessboard[(i), (j)].CompareTo("WQ") == 0)
                        {
                            Current_Move_Score = Current_Move_Score + 9;
                        }
                        else if (CSS_chessboard[(i), (j)].CompareTo("WK") == 0)
                            Current_Move_Score = Current_Move_Score + 15;
                        else if (CSS_chessboard[(i), (j)].CompareTo("BP") == 0)
                            Current_Move_Score = Current_Move_Score - 1;
                        else if (CSS_chessboard[(i), (j)].CompareTo("BR") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 5;
                        }
                        else if (CSS_chessboard[(i), (j)].CompareTo("BN") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 3;

                        }
                        else if (CSS_chessboard[(i), (j)].CompareTo("BB") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 3;
                        }
                        else if (CSS_chessboard[(i), (j)].CompareTo("BQ") == 0)
                        {
                            Current_Move_Score = Current_Move_Score - 9;
                        }
                        else if (CSS_chessboard[(i), (j)].CompareTo("BK") == 0)
                            Current_Move_Score = Current_Move_Score + 15;

                    }
                }

                return Current_Move_Score;
            }



            public static bool legality(string[,] Lchessboard, int checkForDanger, int startRank, int startColumn, int finishRank, int finishColumn, String MovingPiece_2)
            {

                bool legitimacy;


                legitimacy = true;

                if (((finishRank - 1) > 7) || ((finishRank - 1) < 0) || ((finishColumn - 1) > 7) || ((finishColumn - 1) < 0))
                    legitimacy = false;


                if (checkForDanger == 0)
                {
                    if ((MovingPiece_2.CompareTo("WK") == 0) ||
                    (MovingPiece_2.CompareTo("WQ") == 0) ||
                    (MovingPiece_2.CompareTo("WR") == 0) ||
                    (MovingPiece_2.CompareTo("WN") == 0) ||
                    (MovingPiece_2.CompareTo("WB") == 0) ||
                    (MovingPiece_2.CompareTo("WP") == 0))
                    {
                        if ((Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("WK") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("WQ") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("WR") == 0) || 
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("WN") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("WB") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("WP") == 0))
                        {
                            legitimacy = false;
                        }
                    }
                    else if ((MovingPiece_2.CompareTo("BK") == 0) || 
                    (MovingPiece_2.CompareTo("BQ") == 0) ||
                    (MovingPiece_2.CompareTo("BR") == 0) ||
                    (MovingPiece_2.CompareTo("BN") == 0) ||
                    (MovingPiece_2.CompareTo("BB") == 0) ||
                    (MovingPiece_2.CompareTo("BP") == 0))
                    {
                        if ((Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("BK") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("BQ") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("BR") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("BN") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("BB") == 0) ||
                        (Lchessboard[((finishColumn - 1)), ((finishRank - 1))].CompareTo("BP") == 0))
                            legitimacy = false;
                    }
                }

                if (MovingPiece_2.CompareTo("WK") == 0)
                {
                    if (checkForDanger == 0)
                    {

                        Lchessboard[(startColumn - 1), (startRank - 1)] = "";
                        ProsorinoKommati_KingCheck = Lchessboard[(finishColumn - 1), (finishRank - 1)];
                        Lchessboard[(finishColumn - 1), (finishRank - 1)] = "WK";

                        WhiteKingCheck = CheckForWhiteCheck(Lchessboard);

                        if (WhiteKingCheck == true)
                            legitimacy = false;


                        Lchessboard[(startColumn - 1), (startRank - 1)] = "WK";
                        Lchessboard[(finishColumn - 1), (finishRank - 1)] = ProsorinoKommati_KingCheck;
                    }
                }
                else if (MovingPiece_2.CompareTo("BK") == 0)
                {
                    if (checkForDanger == 0)
                    {

                        Lchessboard[(startColumn - 1), (startRank - 1)] = "";
                        ProsorinoKommati_KingCheck = Lchessboard[(finishColumn - 1), (finishRank - 1)];
                        Lchessboard[(finishColumn - 1), (finishRank - 1)] = "BK";

                        BlackKingCheck = CheckForBlackCheck(Lchessboard);

                        if (BlackKingCheck == true)
                            legitimacy = false;


                        Lchessboard[(startColumn - 1), (startRank - 1)] = "BK";
                        Lchessboard[(finishColumn - 1), (finishRank - 1)] = ProsorinoKommati_KingCheck;
                    }
                }
                else if (MovingPiece_2.CompareTo("WP") == 0)
                {
                    if (checkForDanger == 0)
                    {


                        if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                        {
                            if (Lchessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1)
                            {

                                legitimacy = false;
                            }
                        }


                        else if ((finishRank == (startRank + 2)) && (finishColumn == startColumn))
                        {
                            if (startRank == 2)
                            {
                                if ((Lchessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1) ||
                                (Lchessboard[(finishColumn - 1), (finishRank - 1 - 1)].CompareTo("") == 1))
                                    legitimacy = false;
                            }
                        }



                        else if ((finishRank == (startRank + 1)) && (finishColumn == startColumn + 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (Lchessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    legitimacy = false;
                            }
                        }



                        else if ((finishRank == (startRank + 1)) && (finishColumn == startColumn - 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (Lchessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    legitimacy = false;
                            }
                        }
                    }
                }
                else if (MovingPiece_2.CompareTo("BP") == 0)
                {
                    if (checkForDanger == 0)
                    {


                        if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                        {
                            if (Lchessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1)
                                legitimacy = false;
                        }


                        else if ((finishRank == (startRank - 2)) && (finishColumn == startColumn))
                        {
                            if (startRank == 7)
                            {
                                if ((Lchessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 1) ||
                                    (Lchessboard[(finishColumn - 1), (finishRank + 1 - 1)].CompareTo("") == 1))
                                    legitimacy = false;
                            }
                        }



                        else if ((finishRank == (startRank - 1)) && (finishColumn == startColumn + 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (Lchessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    legitimacy = false;
                            }
                        }



                        else if ((finishRank == (startRank - 1)) && (finishColumn == startColumn - 1))
                        {
                            if (enpassant_occured == false)
                            {
                                if (Lchessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("") == 0)
                                    legitimacy = false;
                            }
                        }
                    }
                }
                else if ((MovingPiece_2.CompareTo("WR") == 0) ||
                    (MovingPiece_2.CompareTo("WQ") == 0) ||
                    (MovingPiece_2.CompareTo("WB") == 0) ||
                    (MovingPiece_2.CompareTo("BR") == 0) ||
                    (MovingPiece_2.CompareTo("BQ") == 0) ||
                    (MovingPiece_2.CompareTo("BB") == 0))
                {
                    h = 0;
                    p = 0;

                    how_to_move_Rank = 0;
                    how_to_move_Column = 0;

                    if (((finishRank - 1) > (startRank - 1)) || ((finishRank - 1) < (startRank - 1)))
                        how_to_move_Rank = ((finishRank - 1) - (startRank - 1)) / System.Math.Abs((finishRank - 1) - (startRank - 1));

                    if (((finishColumn - 1) > (startColumn - 1)) || ((finishColumn - 1) < (startColumn - 1)))
                        how_to_move_Column = ((finishColumn - 1) - (startColumn - 1)) / System.Math.Abs((finishColumn - 1) - (startColumn - 1));

                    exit_legim_check = false;

                    do
                    {
                        h = h + how_to_move_Rank;
                        p = p + how_to_move_Column;

                        if ((((startRank - 1) + h) == (finishRank - 1)) && ((((startColumn - 1) + p)) == (finishColumn - 1)))
                            exit_legim_check = true;

                        if ((startColumn - 1 + p) < 0)
                            exit_legim_check = true;
                        else if ((startRank - 1 + h) < 0)
                            exit_legim_check = true;
                        else if ((startColumn - 1 + p) > 7)
                            exit_legim_check = true;
                        else if ((startRank - 1 + h) > 7)
                            exit_legim_check = true;


                        if (exit_legim_check == false)
                        {
                            if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("WR") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("WN") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("WB") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("WQ") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("WK") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("WP") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }

                            if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("BR") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("BN") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("BB") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("BQ") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("BK") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                            else if (Lchessboard[(startColumn - 1 + p), (startRank - 1 + h)].CompareTo("BP") == 0)
                            {
                                legitimacy = false;
                                exit_legim_check = true;
                            }
                        }
                    } while (exit_legim_check == false);
                }
                return legitimacy;
            }



            public static bool correct_check(string[,] EOChessboard, int checkForDanger, int startRank, int startColumn, int finishRank, int finishColumn, String MovingPiece_2)
            {


                bool Rightness;
                Rightness = false;
                enpassant_occured = false;


                if ((m_WhoPlays == 1) && (m_WrongColumn == false) && (MovingPiece_2.CompareTo("") == 1))
                {


                    if ((MovingPiece_2.CompareTo("WR") == 0) || (MovingPiece_2.CompareTo("BR") == 0))
                    {
                        if ((finishColumn != startColumn) && (finishRank == startRank))
                            Rightness = true;
                        else if ((finishRank != startRank) && (finishColumn == startColumn))
                            Rightness = true;
                    }



                    if ((MovingPiece_2.CompareTo("WN") == 0) || (MovingPiece_2.CompareTo("BN") == 0))
                    {
                        if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank + 2)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn + 2)) && (finishRank == (startRank - 1)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank - 2)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank - 2)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn - 2)) && (finishRank == (startRank - 1)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn - 2)) && (finishRank == (startRank + 1)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank + 2)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn + 2)) && (finishRank == (startRank + 1)))
                            Rightness = true;
                    }



                    if ((MovingPiece_2.CompareTo("WB") == 0) || (MovingPiece_2.CompareTo("BB") == 0))
                    {

                        if (((Math.Abs(finishColumn - startColumn)) == (Math.Abs(finishRank - startRank))) && (finishColumn != startColumn) && (finishRank != startRank))
                            Rightness = true;

                    }


                    if ((MovingPiece_2.CompareTo("WQ") == 0) || (MovingPiece_2.CompareTo("BQ") == 0))
                    {
                        if ((finishColumn != startColumn) && (finishRank == startRank))
                            Rightness = true;
                        else if ((finishRank != startRank) && (finishColumn == startColumn))
                            Rightness = true;


                        if (((Math.Abs(finishColumn - startColumn)) == (Math.Abs(finishRank - startRank))) && (finishColumn != startColumn) && (finishRank != startRank))
                            Rightness = true;

                    }



                    if ((MovingPiece_2.CompareTo("WK") == 0) || (MovingPiece_2.CompareTo("BK") == 0))
                    {


                        if ((finishColumn == (startColumn + 1)) && (finishRank == startRank))
                            Rightness = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == startRank))
                            Rightness = true;
                        else if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                            Rightness = true;
                        else if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                            Rightness = true;



                        else if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank + 1)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn + 1)) && (finishRank == (startRank - 1)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank - 1)))
                            Rightness = true;
                        else if ((finishColumn == (startColumn - 1)) && (finishRank == (startRank + 1)))
                            Rightness = true;

                    }



                    if (MovingPiece_2.CompareTo("WP") == 0)
                    {


                        if ((finishRank == (startRank + 1)) && (finishColumn == startColumn))
                            Rightness = true;


                        else if ((finishRank == (startRank + 2)) && (finishColumn == startColumn) && (startRank == 2))
                            Rightness = true;

                        else if ((finishRank == (startRank + 1)) && ((finishColumn == (startColumn - 1)) || (finishColumn == (startColumn + 1))))
                        {
                            if (checkForDanger == 0)
                            {

                                if ((finishRank == (startRank + 1)) &&
                                (finishColumn == (startColumn - 1)) &&
                                ((EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BP") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BR") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BN") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BB") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BQ") == 0)))
                                    Rightness = true;


                                if ((finishRank == (startRank + 1)) && (finishColumn == (startColumn + 1)) &&
                                ((EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BP") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BR") == 0) || 
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BN") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BB") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("BQ") == 0)))
                                    Rightness = true;
                            }
                            else if (checkForDanger == 1)
                            {
                                Rightness = true;
                            }
                        }


                        else if ((finishRank == (startRank + 1)) && (finishColumn == (startColumn - 1)))
                        {
                            if (checkForDanger == 0)
                            {

                                if ((finishRank == 6) && (EOChessboard[(finishColumn - 1), (4)].CompareTo("BP") == 0))
                                {
                                    Rightness = true;
                                    enpassant_occured = true;
                                    EOChessboard[(finishColumn - 1), (finishRank - 1 - 1)] = "";

                                }
                                else
                                {
                                    Rightness = false;
                                    enpassant_occured = false;
                                }
                            }
                        }


                        else if ((finishRank == (startRank + 1)) && (finishColumn == (startColumn + 1)))
                        {
                            if (checkForDanger == 0)
                            {
                                if ((finishRank == 6) && (EOChessboard[(finishColumn - 1), (4)].CompareTo("BP") == 0))
                                {
                                    Rightness = true;
                                    enpassant_occured = true;
                                    EOChessboard[(finishColumn - 1), (finishRank - 1 - 1)] = "";
                                }
                                else
                                {
                                    Rightness = false;
                                    enpassant_occured = false;
                                }
                            }
                        }

                    }




                    if (MovingPiece_2.CompareTo("BP") == 0)
                    {


                        if ((finishRank == (startRank - 1)) && (finishColumn == startColumn))
                            Rightness = true;


                        else if ((finishRank == (startRank - 2)) && (finishColumn == startColumn) && (startRank == 7))
                            Rightness = true;

                        else if ((finishRank == (startRank - 1)) && ((finishColumn == (startColumn + 1)) || (finishColumn == (startColumn - 1))))
                        {
                            if (checkForDanger == 0)
                            {

                                if ((finishRank == (startRank - 1)) && 
                                (finishColumn == (startColumn + 1)) &&
                                ((EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WP") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WR") == 0) || 
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WN") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WB") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WQ") == 0)))
                                    Rightness = true;


                                if ((finishRank == (startRank - 1)) &&
                                (finishColumn == (startColumn - 1)) &&
                                ((EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WP") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WR") == 0) || 
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WN") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WB") == 0) ||
                                (EOChessboard[(finishColumn - 1), (finishRank - 1)].CompareTo("WQ") == 0)))
                                    Rightness = true;
                            }
                            else if (checkForDanger == 1)
                            {

                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn + 1)))
                                    Rightness = true;


                                if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn - 1)))
                                    Rightness = true;
                            }
                        }


                        else if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn + 1)))
                        {
                            if (checkForDanger == 0)
                            {
                                if ((finishRank == 3) && (EOChessboard[(finishColumn - 1), (3)].CompareTo("WP") == 0))
                                {
                                    Rightness = true;
                                    enpassant_occured = true;
                                    EOChessboard[(finishColumn - 1), (finishRank + 1 - 1)] = "";
                                }
                                else
                                {
                                    Rightness = false;
                                    enpassant_occured = false;
                                }
                            }
                        }


                        else if ((finishRank == (startRank - 1)) && (finishColumn == (startColumn - 1)))
                        {
                            if (checkForDanger == 0)
                            {
                                if ((finishRank == 3) && (EOChessboard[(finishColumn - 1), (3)].CompareTo("WP") == 0))
                                {
                                    Rightness = true;
                                    enpassant_occured = true;
                                    EOChessboard[(finishColumn - 1), (finishRank + 1 - 1)] = "";
                                }
                                else
                                {
                                    Rightness = false;
                                    enpassant_occured = false;
                                }
                            }
                        }

                    }

                }


                return Rightness;
            }



            public static void Enter_move()
            {

                if (m_StartingColumn.CompareTo("A") == 0)
                    m_StartingColumnNumber = 1;
                else if (m_StartingColumn.CompareTo("B") == 0)
                    m_StartingColumnNumber = 2;
                else if (m_StartingColumn.CompareTo("C") == 0)
                    m_StartingColumnNumber = 3;
                else if (m_StartingColumn.CompareTo("D") == 0)
                    m_StartingColumnNumber = 4;
                else if (m_StartingColumn.CompareTo("E") == 0)
                    m_StartingColumnNumber = 5;
                else if (m_StartingColumn.CompareTo("F") == 0)
                    m_StartingColumnNumber = 6;
                else if (m_StartingColumn.CompareTo("G") == 0)
                    m_StartingColumnNumber = 7;
                else if (m_StartingColumn.CompareTo("H") == 0)
                    m_StartingColumnNumber = 8;


                if (m_FinishingColumn.CompareTo("A") == 0)
                    m_FinishingColumnNumber = 1;
                else if (m_FinishingColumn.CompareTo("B") == 0)
                    m_FinishingColumnNumber = 2;
                else if (m_FinishingColumn.CompareTo("C") == 0)
                    m_FinishingColumnNumber = 3;
                else if (m_FinishingColumn.CompareTo("D") == 0)
                    m_FinishingColumnNumber = 4;
                else if (m_FinishingColumn.CompareTo("E") == 0)
                    m_FinishingColumnNumber = 5;
                else if (m_FinishingColumn.CompareTo("F") == 0)
                    m_FinishingColumnNumber = 6;
                else if (m_FinishingColumn.CompareTo("G") == 0)
                    m_FinishingColumnNumber = 7;
                else if (m_FinishingColumn.CompareTo("H") == 0)
                    m_FinishingColumnNumber = 8;



                if (m_WhoPlays == 0)
                    Console.WriteLine("Not your turn");

                if (((m_WhoPlays == 1)) && (((m_WhichColorPlays.CompareTo("Wh") == 0) &&
                ((Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("WP") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("WR") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("WN") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("WB") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("WQ") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("WK") == 0))) ||
                    ((m_WhichColorPlays.CompareTo("Bl") == 0) &&
                    ((Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("BP") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("BR") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("BN") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("BB") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("BQ") == 0) ||
                    (Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("BK") == 0)))))
                {

                    m_WrongColumn = false;
                    MovingPiece = Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];
                }
                else
                {
                    m_WrongColumn = true;
                }


                Right_move = correct_check(Chess_board, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);


                if (Right_move == true)
                    legitimal_beh = legality(Chess_board, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);


                Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                Temporary_piece = Chess_board[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                Chess_board[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;


                WhiteKingCheck = CheckForWhiteCheck(Chess_board);

                if ((m_WhichColorPlays.CompareTo("Wh") == 0) && (WhiteKingCheck == true))
                    legitimal_beh = false;


                BlackKingCheck = CheckForBlackCheck(Chess_board);

                if ((m_WhichColorPlays.CompareTo("Bl") == 0) && (BlackKingCheck == true))
                    legitimal_beh = false;


                Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = MovingPiece;
                Chess_board[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = Temporary_piece;



                #region checkCastling


                if ((m_PlayerColor.CompareTo("Wh") == 0) && 
                (m_StartingColumnNumber == 5) && 
                (m_FinishingColumnNumber == 7) &&
                (m_StartingRank == 1) &&
                (m_FinishingRank == 1))
                {
                    if ((Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("WK") == 0) &&
                    (Chess_board[(7), (0)].CompareTo("WR") == 0) && 
                    (Chess_board[(5), (0)].CompareTo("") == 0) && 
                    (Chess_board[(6), (0)].CompareTo("") == 0))
                    {
                        Right_move = true;
                        legitimal_beh = true;
                        Castling_Occured = true;
                    }
                }


                if ((m_PlayerColor.CompareTo("Wh") == 0) && 
                (m_StartingColumnNumber == 5) &&
                (m_FinishingColumnNumber == 3) &&
                (m_StartingRank == 1) && 
                (m_FinishingRank == 1))
                {
                    if ((Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("WK") == 0) &&
                    (Chess_board[(0), (0)].CompareTo("WR") == 0) &&
                    (Chess_board[(1), (0)].CompareTo("") == 0) && 
                    (Chess_board[(2), (0)].CompareTo("") == 0) && 
                    (Chess_board[(3), (0)].CompareTo("") == 0))
                    {
                        Right_move = true;
                        legitimal_beh = true;
                        Castling_Occured = true;
                    }
                }


                if ((m_PlayerColor.CompareTo("Bl") == 0) &&
                (m_StartingColumnNumber == 5) && 
                (m_FinishingColumnNumber == 7) &&
                (m_StartingRank == 8) &&
                (m_FinishingRank == 8))
                {
                    if ((Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("BK") == 0) &&
                    (Chess_board[(7), (7)].CompareTo("BR") == 0) &&
                    (Chess_board[(5), (7)].CompareTo("") == 0) && 
                    (Chess_board[(6), (7)].CompareTo("") == 0))
                    {
                        Right_move = true;
                        legitimal_beh = true;
                        Castling_Occured = true;
                    }
                }


                if ((m_PlayerColor.CompareTo("Bl") == 0) &&
                (m_StartingColumnNumber == 5) &&
                (m_FinishingColumnNumber == 3) &&
                (m_StartingRank == 8) &&
                (m_FinishingRank == 8))
                {
                    if ((Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)].CompareTo("BK") == 0) &&
                    (Chess_board[(0), (7)].CompareTo("BR") == 0) &&
                    (Chess_board[(1), (7)].CompareTo("") == 0) && 
                    (Chess_board[(2), (7)].CompareTo("") == 0) &&
                    (Chess_board[(3), (7)].CompareTo("") == 0))
                    {
                        Right_move = true;
                        legitimal_beh = true;
                        Castling_Occured = true;
                    }
                }
                #endregion checkCastling


                if ((Right_move == true) && (legitimal_beh == true))
                {
                    if ((MovingPiece.CompareTo("WR") == 0) || (MovingPiece.CompareTo("BR") == 0))
                        Value_of_human_moving_piece = 5;
                    if ((MovingPiece.CompareTo("WN") == 0) || (MovingPiece.CompareTo("BN") == 0))
                        Value_of_human_moving_piece = 3;
                    if ((MovingPiece.CompareTo("WB") == 0) || (MovingPiece.CompareTo("BB") == 0))
                        Value_of_human_moving_piece = 3;
                    if ((MovingPiece.CompareTo("WQ") == 0) || (MovingPiece.CompareTo("BQ") == 0))
                        Value_of_human_moving_piece = 9;
                    if ((MovingPiece.CompareTo("WK") == 0) || (MovingPiece.CompareTo("BK") == 0))
                        Value_of_human_moving_piece = 119;
                    if ((MovingPiece.CompareTo("WP") == 0) || (MovingPiece.CompareTo("BP") == 0))
                        Value_of_human_moving_piece = 1;


                    Chess_board[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";

                    Human_last_move_target_column = -1;
                    Human_last_move_target_row = -1;

                    if (Chess_board[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)].CompareTo("") != 0)
                    {
                        Human_last_move_target_column = m_FinishingColumnNumber;
                        Human_last_move_target_row = m_FinishingRank;

                    }


                    Chess_board[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;



                    #region checkEnPassant
                    if (enpassant_occured == true)
                    {
                        if (m_PlayerColor.CompareTo("Wh") == 0)
                            Chess_board[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 - 1)] = "";
                        else if (m_PlayerColor.CompareTo("Bl") == 0)
                            Chess_board[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1 + 1)] = "";
                    }


                    if ((m_StartingRank == 2) && (m_FinishingRank == 4))
                    {
                        enpassant_possible_target_rank = m_FinishingRank - 1;
                        enpassant_possible_target_column = m_FinishingColumnNumber;
                    }
                    else if ((m_StartingRank == 7) && (m_FinishingRank == 5))
                    {
                        enpassant_possible_target_rank = m_FinishingRank + 1;
                        enpassant_possible_target_column = m_FinishingColumnNumber;
                    }
                    else
                    {

                        enpassant_possible_target_rank = -9;
                        enpassant_possible_target_column = -9;
                    }
                    #endregion checkEnPassant


                    #region castlingOccured
                    if (Castling_Occured == true)
                    {
                        if (m_PlayerColor.CompareTo("Wh") == 0)
                        {
                            if (Chess_board[(6), (0)].CompareTo("WK") == 0)
                            {
                                Chess_board[(5), (0)] = "WR";
                                Chess_board[(7), (0)] = "";

                            }
                            else if (Chess_board[(2), (0)].CompareTo("WK") == 0)
                            {
                                Chess_board[(3), (0)] = "WR";
                                Chess_board[(0), (0)] = "";

                            }
                        }
                        else if (m_PlayerColor.CompareTo("Bl") == 0)
                        {
                            if (Chess_board[(6), (7)].CompareTo("BK") == 0)
                            {
                                Chess_board[(5), (7)] = "BR";
                                Chess_board[(7), (7)] = "";

                            }
                            else if (Chess_board[(2), (7)].CompareTo("BK") == 0)
                            {
                                Chess_board[(3), (7)] = "BR";
                                Chess_board[(0), (7)] = "";

                            }
                        }


                        Castling_Occured = false;
                    }
                    #endregion castlingOccured


                    PawnPromotion();


                    m_WhoPlays = 0;


                    if (m_WhichColorPlays.CompareTo("Wh") == 0)
                        m_WhichColorPlays = "Bl";
                    else if (m_WhichColorPlays.CompareTo("Bl") == 0)
                        m_WhichColorPlays = "Wh";


                    m_StartingColumn = "";
                    m_FinishingColumn = "";
                    m_StartingRank = 1;
                    m_FinishingRank = 1;


                    WhiteKingCheck = CheckForWhiteCheck(Chess_board);
                    BlackKingCheck = CheckForBlackCheck(Chess_board);

                    if ((WhiteKingCheck == true) || (BlackKingCheck == true))
                    {
                        Console.WriteLine("CHECK!");
                    }



                    if (m_WhoPlays == 0)
                    {
                        Move_Analyzed = 0;
                        Stop_Analyzing = false;
                        First_Call = true;
                        Finde_the_best_move = false;
                        Who_Is_Analyzed = "HY";

                    }

                }

                else
                {

                    Console.WriteLine("Invalid move");

                }


            }



            public static void PawnPromotion()
            {
                for (i = 0; i <= 7; i++)
                {

                    if ((Chess_board[(i), (0)].CompareTo("BP") == 0) && (m_WhoPlays == 1))
                    {


                        Console.WriteLine("Promote to: 1. Queen, 2. Rook, 3. Knight, 4. Bishop? ");
                        choise_of_user = Int32.Parse(Console.ReadLine());

                        switch (choise_of_user)
                        {
                            case 1:
                                Chess_board[(i), (0)] = "BQ";
                                break;

                            case 2:
                                Chess_board[(i), (0)] = "BR";
                                break;

                            case 3:
                                Chess_board[(i), (0)] = "BN";
                                break;

                            case 4:
                                Chess_board[(i), (0)] = "BB";
                                break;
                        };

                    }


                    if ((Chess_board[(i), (7)].CompareTo("WP") == 0) && (m_WhoPlays == 1))
                    {


                        Console.WriteLine("Promote to: 1. Queen, 2. Rook, 3. Knight, 4. Bishop? ");
                        choise_of_user = Int32.Parse(Console.ReadLine());

                        switch (choise_of_user)
                        {
                            case 1:
                                Chess_board[(i), (0)] = "WQ";
                                break;

                            case 2:
                                Chess_board[(i), (0)] = "WR";
                                break;

                            case 3:
                                Chess_board[(i), (0)] = "WN";
                                break;

                            case 4:
                                Chess_board[(i), (0)] = "WB";
                                break;
                        };
                    }

                }
            }


            public static void Starting_position()
            {


                for (int a = 0; a <= 7; a++)
                {
                    for (int b = 0; b <= 7; b++)
                    {
                        Chess_board[(a), (b)] = "";
                    }
                }

                Chess_board[(0), (0)] = "WR";
                Chess_board[(0), (1)] = "WP";
                Chess_board[(0), (6)] = "BP";
                Chess_board[(0), (7)] = "BR";
                Chess_board[(1), (0)] = "WN";
                Chess_board[(1), (1)] = "WP";
                Chess_board[(1), (6)] = "BP";
                Chess_board[(1), (7)] = "BN";
                Chess_board[(2), (0)] = "WB";
                Chess_board[(2), (1)] = "WP";
                Chess_board[(2), (6)] = "BP";
                Chess_board[(2), (7)] = "BB";
                Chess_board[(3), (0)] = "WQ";
                Chess_board[(3), (1)] = "WP";
                Chess_board[(3), (6)] = "BP";
                Chess_board[(3), (7)] = "BQ";
                Chess_board[(4), (0)] = "WK";
                Chess_board[(4), (1)] = "WP";
                Chess_board[(4), (6)] = "BP";
                Chess_board[(4), (7)] = "BK";
                Chess_board[(5), (0)] = "WB";
                Chess_board[(5), (1)] = "WP";
                Chess_board[(5), (6)] = "BP";
                Chess_board[(5), (7)] = "BB";
                Chess_board[(6), (0)] = "WN";
                Chess_board[(6), (1)] = "WP";
                Chess_board[(6), (6)] = "BP";
                Chess_board[(6), (7)] = "BN";
                Chess_board[(7), (0)] = "WR";
                Chess_board[(7), (1)] = "WP";
                Chess_board[(7), (6)] = "BP";
                Chess_board[(7), (7)] = "BR";

                m_WhichColorPlays = "Wh";
            }

            public static void Analyze_Move_1_HumanMove(string[,] Chessb_Human_Thinking_2)
            {

                int chess;
                int crazy;
                String MovingPiece1;
                String temp_piece;
                int m_StartingColumnNumber1;
                int m_FinishingColumnNumber1;
                int m_StartingRank1;
                int m_FinishingRank1;


                for (chess = 0; chess <= 7; chess++)
                {
                    for (crazy = 0; crazy <= 7; crazy++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("Hu") == 0) && 
                        ((((Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("BK") == 0) ||
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("BQ") == 0) ||
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("BR") == 0) ||
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("BN") == 0) ||
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("BB") == 0) ||
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("BP") == 0)) &&
                        (m_PlayerColor.CompareTo("Bl") == 0)) ||
                        (((Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("WK") == 0) ||
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("WQ") == 0) ||
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("WR") == 0) || 
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("WN") == 0) || 
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("WB") == 0) || 
                        (Chessb_Human_Thinking_2[(chess), (crazy)].CompareTo("WP") == 0)) &&
                        (m_PlayerColor.CompareTo("Wh") == 0)))))
                        {
                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    MovingPiece = Chessb_Human_Thinking_2[(chess), (crazy)];
                                    m_StartingColumnNumber = chess + 1;
                                    m_FinishingColumnNumber = w + 1;
                                    m_StartingRank = crazy + 1;
                                    m_FinishingRank = r + 1;


                                    MovingPiece1 = MovingPiece;
                                    m_StartingColumnNumber1 = m_StartingColumnNumber;
                                    m_FinishingColumnNumber1 = m_FinishingColumnNumber;
                                    m_StartingRank1 = m_StartingRank;
                                    m_FinishingRank1 = m_FinishingRank;
                                    temp_piece = Chessb_Human_Thinking_2[(m_FinishingColumnNumber1 - 1), (m_FinishingRank1 - 1)];


                                    m_WhoPlays = 1;
                                    m_WrongColumn = false;
                                    MovingPiece = Chessb_Human_Thinking_2[(m_StartingColumnNumber - 1), (m_StartingRank - 1)];
                                    Right_move = correct_check(Chessb_Human_Thinking_2, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                                    legitimal_beh = legality(Chessb_Human_Thinking_2, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                                    m_WhoPlays = 0;


                                    if ((Right_move == true) && (legitimal_beh == true))
                                    {

                                        Temporary_piece = Chessb_Human_Thinking_2[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                        Chessb_Human_Thinking_2[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                        Chessb_Human_Thinking_2[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;


                                        if (Move_Analyzed == 1)
                                        {
                                            NodeLevel_1_count++;
                                            Temp_Score_Move_1_human = CountScore(Chessb_Human_Thinking_2);
                                        }

                                        if (Move_Analyzed < Thinking_Depth)
                                        {

                                            Move_Analyzed = Move_Analyzed + 1;

                                            Who_Is_Analyzed = "HY";

                                            for (i = 0; i <= 7; i++)
                                            {
                                                for (j = 0; j <= 7; j++)
                                                {
                                                    Chessboard_Move_After[(i), (j)] = Chessb_Human_Thinking_2[(i), (j)];
                                                }
                                            }

                                            if (Move_Analyzed == 2)
                                                Analyze_Move_2_ComputerMove(Chessboard_Move_After);
                                        }


                                        Chessb_Human_Thinking_2[(m_StartingColumnNumber1 - 1), (m_StartingRank1 - 1)] = MovingPiece1;
                                        Chessb_Human_Thinking_2[(m_FinishingColumnNumber1 - 1), (m_FinishingRank1 - 1)] = temp_piece;
                                    }

                                }
                            }

                        }

                    }
                }

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "HY";
            }


            public static void Analyze_Move_2_ComputerMove(string[,] Chessbo_Thinking_)
            {

                int iii2;
                int jjj2;
                String MovingPiece2;
                String ProsorinoKommati2;
                int m_StartingColumnNumber2;
                int m_FinishingColumnNumber2;
                int m_StartingRank2;
                int m_FinishingRank2;



                for (iii2 = 0; iii2 <= 7; iii2++)
                {
                    for (jjj2 = 0; jjj2 <= 7; jjj2++)
                    {

                        if (((Who_Is_Analyzed.CompareTo("HY") == 0) &&
                        ((((Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("WK") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("WQ") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("WR") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("WN") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("WB") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("WP") == 0)) &&
                            (m_PlayerColor.CompareTo("Bl") == 0)) ||
                            (((Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("BK") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("BQ") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("BR") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("BN") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("BB") == 0) ||
                            (Chessbo_Thinking_[(iii2), (jjj2)].CompareTo("BP") == 0)) &&
                            (m_PlayerColor.CompareTo("Wh") == 0)))))
                        {


                            for (int w = 0; w <= 7; w++)
                            {
                                for (int r = 0; r <= 7; r++)
                                {
                                    MovingPiece = Chessbo_Thinking_[(iii2), (jjj2)];
                                    m_StartingColumnNumber = iii2 + 1;
                                    m_FinishingColumnNumber = w + 1;
                                    m_StartingRank = jjj2 + 1;
                                    m_FinishingRank = r + 1;


                                    MovingPiece2 = MovingPiece;
                                    m_StartingColumnNumber2 = m_StartingColumnNumber;
                                    m_FinishingColumnNumber2 = m_FinishingColumnNumber;
                                    m_StartingRank2 = m_StartingRank;
                                    m_FinishingRank2 = m_FinishingRank;
                                    ProsorinoKommati2 = Chessbo_Thinking_[(m_FinishingColumnNumber2 - 1), (m_FinishingRank2 - 1)];

                                    m_WhoPlays = 1;
                                    m_WrongColumn = false;
                                    Right_move = correct_check(Chessbo_Thinking_, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);
                                    legitimal_beh = legality(Chessbo_Thinking_, 0, m_StartingRank, m_StartingColumnNumber, m_FinishingRank, m_FinishingColumnNumber, MovingPiece);

                                    m_WhoPlays = 0;

                                    if ((Right_move == true) && (legitimal_beh == true))
                                    {

                                        Temporary_piece = Chessbo_Thinking_[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)];
                                        Chessbo_Thinking_[(m_StartingColumnNumber - 1), (m_StartingRank - 1)] = "";
                                        Chessbo_Thinking_[(m_FinishingColumnNumber - 1), (m_FinishingRank - 1)] = MovingPiece;


                                        if (Move_Analyzed == 2)
                                        {
                                            NodeLevel_2_count++;

                                            Temp_Score_Move_2 = CountScore(Chessbo_Thinking_);
                                        }

                                        if (Move_Analyzed == Thinking_Depth)
                                        {

                                            NodesAnalysis0[NodeLevel_0_count, 0] = Temp_Score_Move_0;
                                            NodesAnalysis1[NodeLevel_1_count, 0] = Temp_Score_Move_1_human;
                                            NodesAnalysis2[NodeLevel_2_count, 0] = Temp_Score_Move_2;


                                            NodesAnalysis0[NodeLevel_0_count, 1] = 0;
                                            NodesAnalysis1[NodeLevel_1_count, 1] = NodeLevel_0_count;
                                            NodesAnalysis2[NodeLevel_2_count, 1] = NodeLevel_1_count;


                                        }


                                        Chessbo_Thinking_[(m_StartingColumnNumber2 - 1), (m_StartingRank2 - 1)] = MovingPiece2;
                                        Chessbo_Thinking_[(m_FinishingColumnNumber2 - 1), (m_FinishingRank2 - 1)] = ProsorinoKommati2;
                                    }

                                }
                            }

                        }


                    }
                }

                Move_Analyzed = Move_Analyzed - 1;
                Who_Is_Analyzed = "Hu";
            }

            public static void FindAttackers(string[,] ChessboardAttackers)
            {
                String MovingPiece_Attack;
                int m_StartingRank_Attack;
                int m_StartingColumnNumber_Attack;
                int m_FinishingRank_Attack;
                int m_FinishingColumnNumber_Attack;


                for (int iii2 = 0; iii2 <= 7; iii2++)
                {
                    for (int jjj2 = 0; jjj2 <= 7; jjj2++)
                    {
                        if ((((ChessboardAttackers[(iii2), (jjj2)].CompareTo("WK") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("WQ") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("WR") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("WN") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("WB") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("WP") == 0)) && 
                            (m_PlayerColor.CompareTo("Wh") == 0)) ||
                            (((ChessboardAttackers[(iii2), (jjj2)].CompareTo("BK") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("BQ") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("BR") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("BN") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("BB") == 0) ||
                            (ChessboardAttackers[(iii2), (jjj2)].CompareTo("BP") == 0)) && 
                            (m_PlayerColor.CompareTo("Bl") == 0)))
                        {

                            MovingPiece_Attack = ChessboardAttackers[(iii2), (jjj2)];
                            m_StartingColumnNumber_Attack = iii2 + 1;
                            m_StartingRank_Attack = jjj2 + 1;


                            for (int w2 = 0; w2 <= 7; w2++)
                            {
                                for (int r2 = 0; r2 <= 7; r2++)
                                {
                                    m_FinishingColumnNumber_Attack = w2 + 1;
                                    m_FinishingRank_Attack = r2 + 1;


                                    m_WhoPlays = 1;
                                    m_WrongColumn = false;
                                    Right_move = correct_check(Chess_board, 1, m_StartingRank_Attack, m_StartingColumnNumber_Attack, m_FinishingRank_Attack, m_FinishingColumnNumber_Attack, MovingPiece_Attack);
                                    if (Right_move == true)
                                    {
                                        legitimal_beh = legality(Chess_board, 1, m_StartingRank_Attack, m_StartingColumnNumber_Attack, m_FinishingRank_Attack, m_FinishingColumnNumber_Attack, MovingPiece_Attack);
                                    }

                                    m_WhoPlays = 0;
                                    if ((MovingPiece_Attack.CompareTo("WP") == 0) || (MovingPiece_Attack.CompareTo("BP") == 0))
                                    {
                                        if (m_FinishingColumnNumber_Attack == m_StartingColumnNumber_Attack)
                                        {
                                            Right_move = false;
                                        }
                                    }

                                    if ((Right_move == true) && (legitimal_beh == true))
                                    {

                                        Number_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Number_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 1;


                                        if ((MovingPiece_Attack.CompareTo("WR") == 0) ||
                                        (MovingPiece_Attack.CompareTo("BR") == 0))
                                            Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 5;
                                        else if ((MovingPiece_Attack.CompareTo("WB") == 0) ||
                                        (MovingPiece_Attack.CompareTo("BB") == 0))
                                            Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 3;
                                        else if ((MovingPiece_Attack.CompareTo("WN") == 0) ||
                                        (MovingPiece_Attack.CompareTo("BN") == 0))
                                            Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 3;
                                        else if ((MovingPiece_Attack.CompareTo("WQ") == 0) ||
                                        (MovingPiece_Attack.CompareTo("BQ") == 0))
                                            Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 9;
                                        else if ((MovingPiece_Attack.CompareTo("WP") == 0) ||
                                        (MovingPiece_Attack.CompareTo("BP") == 0))
                                            Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_attack[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 1;

                                    }
                                }
                            }
                        }
                    }
                }


            }

            public static void FindDefenders(string[,] ChessboardDefenders)
            {
                String MovingPiece_Attack;
                int m_StartingRank_Attack;
                int m_StartingColumnNumber_Attack;
                int m_FinishingRank_Attack;
                int m_FinishingColumnNumber_Attack;


                for (int iii3 = 0; iii3 <= 7; iii3++)
                {
                    for (int jjj3 = 0; jjj3 <= 7; jjj3++)
                    {
                        if ((((ChessboardDefenders[(iii3), (jjj3)].CompareTo("WK") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("WQ") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("WR") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("WN") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("WB") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("WP") == 0)) && (m_PlayerColor.CompareTo("Bl") == 0)) ||
                            (((ChessboardDefenders[(iii3), (jjj3)].CompareTo("BK") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("BQ") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("BR") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("BN") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("BB") == 0) ||
                            (ChessboardDefenders[(iii3), (jjj3)].CompareTo("BP") == 0)) && (m_PlayerColor.CompareTo("Wh") == 0)))
                        {

                            MovingPiece_Attack = ChessboardDefenders[(iii3), (jjj3)];
                            m_StartingColumnNumber_Attack = iii3 + 1;
                            m_StartingRank_Attack = jjj3 + 1;

                            for (int w1 = 0; w1 <= 7; w1++)
                            {
                                for (int r1 = 0; r1 <= 7; r1++)
                                {

                                    m_FinishingColumnNumber_Attack = w1 + 1;
                                    m_FinishingRank_Attack = r1 + 1;


                                    m_WhoPlays = 1;
                                    m_WrongColumn = false;
                                    Right_move = correct_check(ChessboardDefenders, 1, m_StartingRank_Attack, m_StartingColumnNumber_Attack, m_FinishingRank_Attack, m_FinishingColumnNumber_Attack, MovingPiece_Attack);
                                    if (Right_move == true)
                                    {
                                        legitimal_beh = legality(ChessboardDefenders, 1, m_StartingRank_Attack, m_StartingColumnNumber_Attack, m_FinishingRank_Attack, m_FinishingColumnNumber_Attack, MovingPiece_Attack);
                                    }

                                    m_WhoPlays = 0;

                                    if ((MovingPiece_Attack.CompareTo("WP") == 0) || (MovingPiece_Attack.CompareTo("BP") == 0))
                                    {
                                        if (m_FinishingColumnNumber_Attack == m_StartingColumnNumber_Attack)
                                        {
                                            Right_move = false;
                                        }
                                    }


                                    m_WhoPlays = 0;
                                    if ((Right_move == true) && (legitimal_beh == true))
                                    {

                                        Number_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Number_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 1;


                                        if ((MovingPiece_Attack.CompareTo("WR") == 0) || (MovingPiece_Attack.CompareTo("BR") == 0))
                                            Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 5;
                                        else if ((MovingPiece_Attack.CompareTo("WB") == 0) || (MovingPiece_Attack.CompareTo("BB") == 0))
                                            Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 3;
                                        else if ((MovingPiece_Attack.CompareTo("WN") == 0) || (MovingPiece_Attack.CompareTo("BN") == 0))
                                            Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 3;
                                        else if ((MovingPiece_Attack.CompareTo("WQ") == 0) || (MovingPiece_Attack.CompareTo("BQ") == 0))
                                            Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 9;
                                        else if ((MovingPiece_Attack.CompareTo("WP") == 0) || (MovingPiece_Attack.CompareTo("BP") == 0))
                                            Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 1;
                                        else if ((MovingPiece_Attack.CompareTo("WK") == 0) || (MovingPiece_Attack.CompareTo("BK") == 0))
                                            Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] = Value_of_defend[(m_FinishingColumnNumber_Attack - 1), (m_FinishingRank_Attack - 1)] + 15;


                                    }
                                }
                            }
                        }
                    }
                }
            }

        };
    


}
