using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AdvancedScada.HMIs.Drawing
{
	internal class INBase
	{
		internal string a(HMIImageLibraryItem A_0)
		{
			string result = "";
			switch (A_0)
			{
			case HMIImageLibraryItem.ILV_Valve1:
				return "VALVE1";
			case HMIImageLibraryItem.ILV_Valve3:
				return "VALVE3";
			case HMIImageLibraryItem.ILV_Valve5:
				return "VALVE5";
			case HMIImageLibraryItem.ILV_Valve6:
				return "VALVE6";
			case HMIImageLibraryItem.ILV_Valve7:
				return "VALVE7";
			case HMIImageLibraryItem.ILV_Valve8:
				return "VALVE8";
			case HMIImageLibraryItem.ILV_Valve9:
				return "VALVE9";
			case HMIImageLibraryItem.ILV_Valve10:
				return "VALVE10";
			case HMIImageLibraryItem.ILV_Valve14:
				return "VALVE14";
			case HMIImageLibraryItem.ILV_Valve15:
				return "VALVE15";
			case HMIImageLibraryItem.ILV_Valve17:
				return "VALVE17";
			case HMIImageLibraryItem.ILV_Valve21:
				return "VALVE21";
			case HMIImageLibraryItem.ILV_Valve22:
				return "VALVE22";
			case HMIImageLibraryItem.ILV_Valve24:
				return "VALVE24";
			case HMIImageLibraryItem.ILV_Valve25:
				return "VALVE25";
			case HMIImageLibraryItem.ILV_Valve26:
				return "VALVE26";
			case HMIImageLibraryItem.ILV_Valve29:
				return "VALVE29";
			case HMIImageLibraryItem.ILV_Valve33:
				return "VALVE33";
			case HMIImageLibraryItem.ILV_Valve34:
				return "VALVE34";
			case HMIImageLibraryItem.ILV_Valve36:
				return "VALVE36";
			case HMIImageLibraryItem.ILV_Valve38:
				return "VALVE38";
			case HMIImageLibraryItem.ILT_Tank1:
				return "TANK1";
			case HMIImageLibraryItem.ILT_Tank2:
				return "TANK2";
			case HMIImageLibraryItem.ILT_Tank3:
				return "TANK3";
			case HMIImageLibraryItem.ILT_Tank5:
				return "TANK5";
			case HMIImageLibraryItem.ILT_Tank7:
				return "TANK7";
			case HMIImageLibraryItem.ILT_Tank10:
				return "TANK10";
			case HMIImageLibraryItem.ILT_Tank11:
				return "TANK11";
			case HMIImageLibraryItem.ILT_Tank15:
				return "TANK15";
			case HMIImageLibraryItem.ILT_Tank16:
				return "TANK16";
			case HMIImageLibraryItem.ILT_Tank17:
				return "TANK17";
			case HMIImageLibraryItem.ILT_Tank19:
				return "TANK19";
			case HMIImageLibraryItem.ILT_Tank21:
				return "TANK21";
			case HMIImageLibraryItem.ILT_Tank23:
				return "TANK23";
			case HMIImageLibraryItem.ILT_Tank24:
				return "TANK24";
			case HMIImageLibraryItem.ILT_Tank26:
				return "TANK26";
			case HMIImageLibraryItem.ILT_Tank27:
				return "TANK27";
			case HMIImageLibraryItem.ILT_Tank28:
				return "TANK28";
			case HMIImageLibraryItem.ILT_Tank33:
				return "TANK33";
			case HMIImageLibraryItem.ILT_Tank34:
				return "TANK34";
			case HMIImageLibraryItem.ILT_Tank38:
				return "TANK38";
			case HMIImageLibraryItem.ILT_Tank40:
				return "TANK40";
			case HMIImageLibraryItem.ILP_Pump3:
				return "PUMP3";
			case HMIImageLibraryItem.ILP_Pump4:
				return "PUMP4";
			case HMIImageLibraryItem.ILP_Pump6:
				return "PUMP6";
			case HMIImageLibraryItem.ILP_Pump8:
				return "PUMP8";
			case HMIImageLibraryItem.ILP_Pump9:
				return "PUMP9";
			case HMIImageLibraryItem.ILP_Pump10:
				return "PUMP10";
			case HMIImageLibraryItem.ILP_Pump11:
				return "PUMP11";
			case HMIImageLibraryItem.ILP_Pump13:
				return "PUMP13";
			case HMIImageLibraryItem.ILP_Pump14:
				return "PUMP14";
			case HMIImageLibraryItem.ILP_Pump15:
				return "PUMP15";
			case HMIImageLibraryItem.ILP_Pump16:
				return "PUMP16";
			case HMIImageLibraryItem.ILP_Pump19:
				return "PUMP19";
			case HMIImageLibraryItem.ILP_Pump20:
				return "PUMP20";
			case HMIImageLibraryItem.ILP_Pump24:
				return "PUMP24";
			case HMIImageLibraryItem.ILP_Pump27:
				return "PUMP27";
			case HMIImageLibraryItem.ILP_Pump28:
				return "PUMP28";
			case HMIImageLibraryItem.ILDB_BIT_Motor2:
				return "Motor2";
			default:
				switch (A_0)
				{
				case HMIImageLibraryItem.ILDB_BIT_Motor1:
					return "Motor1";
				default:
					if (A_0 != HMIImageLibraryItem.ILDB_BIT_Motor1)
					{
						if (A_0 == HMIImageLibraryItem.ILDB_BIT_Motor2)
						{
							return "Motor2";
						}
						if (A_0 != HMIImageLibraryItem.ILDB_BIT_Motor3)
						{
							if (A_0 == HMIImageLibraryItem.ILDB_BIT_Motor4)
							{
								return "Motor4";
							}
							if (A_0 == HMIImageLibraryItem.ILDB_BIT_Motor5)
							{
								return "Motor5";
							}
							if (A_0 == HMIImageLibraryItem.ILDB_BIT_Motor6)
							{
								return "Motor6";
							}
							if (A_0 == HMIImageLibraryItem.ILDB_BIT_Motor7)
							{
								return "Motor7";
							}
							if (A_0 != HMIImageLibraryItem.ILDB_BIT_Motor8)
							{
								if (A_0 == HMIImageLibraryItem.ILDB_BIT_Motor9)
								{
									return "Motor9";
								}
								if (A_0 != HMIImageLibraryItem.ILDB_BIT_Motor10)
								{
									if (A_0 == HMIImageLibraryItem.ILDB_BIT_Motor11)
									{
										return "Motor11";
									}
									if (A_0 == HMIImageLibraryItem.ILDB_BIT_Motor12)
									{
										return "Motor12";
									}
									if (A_0 != HMIImageLibraryItem.ILDB_BIT_Motor13)
									{
										if (A_0 == HMIImageLibraryItem.ILDB_BIT_Meter1)
										{
											return "METER1";
										}
										if (A_0 != HMIImageLibraryItem.ILDB_BIT_Meter2)
										{
											if (A_0 == HMIImageLibraryItem.ILDB_BIT_Meter3)
											{
												return "METER3";
											}
											if (A_0 == HMIImageLibraryItem.ILDB_BIT_Meter4)
											{
												return "METER4";
											}
											if (A_0 == HMIImageLibraryItem.ILDB_BIT_Meter5)
											{
												return "METER5";
											}
											if (A_0 != HMIImageLibraryItem.ILDB_BIT_Meter6)
											{
												if (A_0 != HMIImageLibraryItem.ILDB_BIT_Meter7)
												{
													if (A_0 != HMIImageLibraryItem.ILDB_BIT_Meter8)
													{
														if (A_0 == HMIImageLibraryItem.ILDB_BIT_Meter9)
														{
															return "METER9";
														}
														if (A_0 != HMIImageLibraryItem.ILH_HeatCool1)
														{
															if (A_0 == HMIImageLibraryItem.ILH_HeatCool2)
															{
																return "HEATCOOL2";
															}
															if (A_0 == HMIImageLibraryItem.ILH_HeatCool3)
															{
																return "HEATCOOL3";
															}
															if (A_0 == HMIImageLibraryItem.ILH_HeatCool4)
															{
																return "HEATCOOL4";
															}
															if (A_0 == HMIImageLibraryItem.ILH_HeatCool5)
															{
																return "HEATCOOL5";
															}
															if (A_0 != HMIImageLibraryItem.ILH_HeatCool6)
															{
																if (A_0 != HMIImageLibraryItem.ILH_HeatCool7)
																{
																	if (A_0 != HMIImageLibraryItem.ILH_HeatCool8)
																	{
																		if (A_0 == HMIImageLibraryItem.ILH_HeatCool9)
																		{
																			return "HEATCOOL9";
																		}
																		if (A_0 == HMIImageLibraryItem.ILH_HeatCool10)
																		{
																			return "HEATCOOL10";
																		}
																		if (A_0 != HMIImageLibraryItem.ILH_HeatCool11)
																		{
																			if (A_0 == HMIImageLibraryItem.ILH_HeatCool12)
																			{
																				return "HEATCOOL12";
																			}
																			if (A_0 != HMIImageLibraryItem.ILH_HeatCool13)
																			{
																				if (A_0 != HMIImageLibraryItem.ILH_HeatCool14)
																				{
																					if (A_0 == HMIImageLibraryItem.ILH_HeatCool15)
																					{
																						return "HEATCOOL15";
																					}
																					if (A_0 != HMIImageLibraryItem.ILH_HeatCool16)
																					{
																						if (A_0 == HMIImageLibraryItem.ILH_HeatCool17)
																						{
																							return "HEATCOOL17";
																						}
																						if (A_0 != HMIImageLibraryItem.ILH_HeatCool18)
																						{
																							if (A_0 != HMIImageLibraryItem.ILH_HeatCool19)
																							{
																								if (A_0 == HMIImageLibraryItem.ILH_HeatCool20)
																								{
																									return "HEATCOOL20";
																								}
																								if (A_0 == HMIImageLibraryItem.ILH_HeatCool21)
																								{
																									return "HEATCOOL21";
																								}
																								if (A_0 == HMIImageLibraryItem.ILH_HeatCool22)
																								{
																									return "HEATCOOL22";
																								}
																								if (A_0 != HMIImageLibraryItem.ILH_HeatCool23)
																								{
																									if (A_0 != HMIImageLibraryItem.ILH_HeatCool24)
																									{
																										if (A_0 != HMIImageLibraryItem.ILH_HeatCool25)
																										{
																											if (A_0 == HMIImageLibraryItem.ILH_HeatCool26)
																											{
																												return "HEATCOOL26";
																											}
																											if (A_0 != HMIImageLibraryItem.ILH_HeatCool27)
																											{
																												if (A_0 == HMIImageLibraryItem.ILH_HeatCool28)
																												{
																													return "HEATCOOL28";
																												}
																												if (A_0 == HMIImageLibraryItem.ILH_HeatCool29)
																												{
																													return "HEATCOOL29";
																												}
																												if (A_0 == HMIImageLibraryItem.ILH_HeatCool30)
																												{
																													return "HEATCOOL30";
																												}
																												if (A_0 == HMIImageLibraryItem.ILH_HeatCool31)
																												{
																													return "HEATCOOL31";
																												}
																												if (A_0 != HMIImageLibraryItem.ILH_HeatCool32)
																												{
																													if (A_0 == HMIImageLibraryItem.ILC_Conveyor1)
																													{
																														return "CONVEYOR1";
																													}
																													if (A_0 == HMIImageLibraryItem.ILC_Conveyor2)
																													{
																														return "CONVEYOR2";
																													}
																													if (A_0 != HMIImageLibraryItem.ILC_Conveyor3)
																													{
																														if (A_0 != HMIImageLibraryItem.ILC_Conveyor4)
																														{
																															if (A_0 != HMIImageLibraryItem.ILC_Conveyor5)
																															{
																																if (A_0 == HMIImageLibraryItem.ILC_Controller1)
																																{
																																	return "CONTROLLER1";
																																}
																																if (A_0 == HMIImageLibraryItem.ILC_Controller2)
																																{
																																	return "CONTROLLER2";
																																}
																																if (A_0 == HMIImageLibraryItem.ILC_Controller3)
																																{
																																	return "CONTROLLER3";
																																}
																																if (A_0 != HMIImageLibraryItem.ILC_Controller4)
																																{
																																	if (A_0 != HMIImageLibraryItem.ILC_Controller5)
																																	{
																																		if (A_0 == HMIImageLibraryItem.ILC_Controller6)
																																		{
																																			return "CONTROLLER6";
																																		}
																																		if (A_0 != HMIImageLibraryItem.ILB_Blower1)
																																		{
																																			if (A_0 != HMIImageLibraryItem.ILB_Blower2)
																																			{
																																				if (A_0 != HMIImageLibraryItem.ILB_Blower3)
																																				{
																																					if (A_0 == HMIImageLibraryItem.ILB_Blower4)
																																					{
																																						return "BLOWER4";
																																					}
																																					if (A_0 != HMIImageLibraryItem.ILB_Blower5)
																																					{
																																						if (A_0 != HMIImageLibraryItem.ILB_Blower6)
																																						{
																																							if (A_0 == HMIImageLibraryItem.ILB_Blower7)
																																							{
																																								return "BLOWER7";
																																							}
																																							if (A_0 != HMIImageLibraryItem.ILB_Blower8)
																																							{
																																								if (A_0 == HMIImageLibraryItem.ILB_Blower9)
																																								{
																																									return "BLOWER9";
																																								}
																																								if (A_0 == HMIImageLibraryItem.ILB_Blower10)
																																								{
																																									return "BLOWER10";
																																								}
																																								if (A_0 == HMIImageLibraryItem.ILB_Blender1)
																																								{
																																									return "Blender1";
																																								}
																																								if (A_0 == HMIImageLibraryItem.ILB_Blender2)
																																								{
																																									return "Blender2";
																																								}
																																								if (A_0 == HMIImageLibraryItem.ILB_Blender3)
																																								{
																																									return "Blender3";
																																								}
																																								if (A_0 == HMIImageLibraryItem.ILB_Blender4)
																																								{
																																									return "Blender4";
																																								}
																																								if (A_0 != HMIImageLibraryItem.ILB_Blender5)
																																								{
																																									switch (A_0)
																																									{
																																									case HMIImageLibraryItem.ILB_Blender6:
																																										return "Blender6";
																																									case HMIImageLibraryItem.ILB_Blender7:
																																										result = "Blender7";
																																										break;
																																									}
																																									return result;
																																								}
																																								return "Blender5";
																																							}
																																							return "BLOWER8";
																																						}
																																						return "BLOWER6";
																																					}
																																					return "BLOWER5";
																																				}
																																				return "BLOWER3";
																																			}
																																			return "BLOWER2";
																																		}
																																		return "BLOWER1";
																																	}
																																	return "CONTROLLER5";
																																}
																																return "CONTROLLER4";
																															}
																															return "CONVEYOR5";
																														}
																														return "CONVEYOR4";
																													}
																													return "CONVEYOR3";
																												}
																												return "HEATCOOL32";
																											}
																											return "HEATCOOL27";
																										}
																										return "HEATCOOL25";
																									}
																									return "HEATCOOL24";
																								}
																								return "HEATCOOL23";
																							}
																							return "HEATCOOL19";
																						}
																						return "HEATCOOL18";
																					}
																					return "HEATCOOL16";
																				}
																				return "HEATCOOL14";
																			}
																			return "HEATCOOL13";
																		}
																		return "HEATCOOL11";
																	}
																	return "HEATCOOL8";
																}
																return "HEATCOOL7";
															}
															return "HEATCOOL6";
														}
														return "HEATCOOL1";
													}
													return "METER8";
												}
												return "METER7";
											}
											return "METER6";
										}
										return "METER2";
									}
									return "Motor13";
								}
								return "Motor10";
							}
							return "Motor8";
						}
						return "Motor3";
					}
					return "Motor1";
				case HMIImageLibraryItem.ILDB_BIT_Motor2:
					return "Motor2";
				}
			case HMIImageLibraryItem.ILDB_BIT_Motor1:
				return "Motor1";
			case HMIImageLibraryItem.ILP_Pump26:
				return "PUMP26";
			case HMIImageLibraryItem.ILP_Pump25:
				return "PUMP25";
			case HMIImageLibraryItem.ILP_Pump23:
				return "PUMP23";
			case HMIImageLibraryItem.ILP_Pump22:
				return "PUMP22";
			case HMIImageLibraryItem.ILP_Pump21:
				return "PUMP21";
			case HMIImageLibraryItem.ILP_Pump18:
				return "PUMP18";
			case HMIImageLibraryItem.ILP_Pump17:
				return "PUMP17";
			case HMIImageLibraryItem.ILP_Pump12:
				return "PUMP12";
			case HMIImageLibraryItem.ILP_Pump7:
				return "PUMP7";
			case HMIImageLibraryItem.ILP_Pump5:
				return "PUMP5";
			case HMIImageLibraryItem.ILP_Pump2:
				return "PUMP2";
			case HMIImageLibraryItem.ILP_Pump1:
				return "PUMP1";
			case HMIImageLibraryItem.ILT_Tank39:
				return "TANK39";
			case HMIImageLibraryItem.ILT_Tank37:
				return "TANK37";
			case HMIImageLibraryItem.ILT_Tank36:
				return "TANK36";
			case HMIImageLibraryItem.ILT_Tank35:
				return "TANK35";
			case HMIImageLibraryItem.ILT_Tank32:
				return "TANK32";
			case HMIImageLibraryItem.ILT_Tank31:
				return "TANK31";
			case HMIImageLibraryItem.ILT_Tank30:
				return "TANK30";
			case HMIImageLibraryItem.ILT_Tank29:
				return "TANK29";
			case HMIImageLibraryItem.ILT_Tank25:
				return "TANK25";
			case HMIImageLibraryItem.ILT_Tank22:
				return "TANK22";
			case HMIImageLibraryItem.ILT_Tank20:
				return "TANK20";
			case HMIImageLibraryItem.ILT_Tank18:
				return "TANK18";
			case HMIImageLibraryItem.ILT_Tank14:
				return "TANK14";
			case HMIImageLibraryItem.ILT_Tank13:
				return "TANK13";
			case HMIImageLibraryItem.ILT_Tank12:
				return "TANK12";
			case HMIImageLibraryItem.ILT_Tank9:
				return "TANK9";
			case HMIImageLibraryItem.ILT_Tank8:
				return "TANK8";
			case HMIImageLibraryItem.ILT_Tank6:
				return "TANK6";
			case HMIImageLibraryItem.ILT_Tank4:
				return "TANK4";
			case HMIImageLibraryItem.ILV_Valve37:
				return "VALVE37";
			case HMIImageLibraryItem.ILV_Valve35:
				return "VALVE35";
			case HMIImageLibraryItem.ILV_Valve32:
				return "VALVE32";
			case HMIImageLibraryItem.ILV_Valve31:
				return "VALVE31";
			case HMIImageLibraryItem.ILV_Valve30:
				return "VALVE30";
			case HMIImageLibraryItem.ILV_Valve28:
				return "VALVE28";
			case HMIImageLibraryItem.ILV_Valve27:
				return "VALVE27";
			case HMIImageLibraryItem.ILV_Valve23:
				return "VALVE23";
			case HMIImageLibraryItem.ILV_Valve20:
				return "VALVE20";
			case HMIImageLibraryItem.ILV_Valve19:
				return "VALVE19";
			case HMIImageLibraryItem.ILV_Valve18:
				return "VALVE18";
			case HMIImageLibraryItem.ILV_Valve16:
				return "VALVE16";
			case HMIImageLibraryItem.ILV_Valve13:
				return "VALVE13";
			case HMIImageLibraryItem.ILV_Valve12:
				return "VALVE12";
			case HMIImageLibraryItem.ILV_Valve11:
				return "VALVE11";
			case HMIImageLibraryItem.ILV_Valve4:
				return "VALVE4";
			case HMIImageLibraryItem.ILV_Valve2:
				return "VALVE2";
			}
		}

		internal void a(GraphicsPath A_0, Rectangle A_1, int A_2)
		{
			int num = A_2;
			int left = A_1.Left;
			int top = A_1.Top;
			int num2 = A_1.Width - 1;
			int num3 = A_1.Height - 1;
			if (2 * num > num2)
			{
				num = num2 / 2;
			}
			if (2 * num > num3)
			{
				num = num3 / 2;
			}
			if (num <= 0)
			{
				A_0.AddLine(left, top, left + num2, top);
				A_0.AddLine(left + num2, top, left + num2, top + num3);
				A_0.AddLine(left + num2, top + num3, left, top + num3);
				A_0.AddLine(left, top + num3, left, top);
			}
			else
			{
				A_0.AddLine(left + num, top, left + num2 - num, top);
				A_0.AddArc(left + num2 - 2 * num, top, 2 * num, 2 * num, 270f, 90f);
				A_0.AddLine(left + num2, top + num, left + num2, top + num3 - num);
				A_0.AddArc(left + num2 - 2 * num, top + num3 - 2 * num, 2 * num, 2 * num, 0f, 90f);
				A_0.AddLine(left + num2 - num, top + num3, left + num, top + num3);
				A_0.AddArc(left, top + num3 - 2 * num, 2 * num, 2 * num, 90f, 90f);
				A_0.AddLine(left, top + num3 - num, left, top + num);
				A_0.AddArc(left, top, 2 * num, 2 * num, 180f, 90f);
			}
			A_0.CloseFigure();
		}

		internal void a(Graphics A_0, Rectangle A_1, GraphicsPath A_2, Color A_3, Color A_4, int A_5)
		{
			Blend blend = new Blend
			{
				Factors = new float[3],
				Positions = new float[3]
			};
			blend.Factors[0] = 0f;
			blend.Positions[0] = 0f;
			blend.Factors[1] = 1f;
			blend.Positions[1] = 0.5f;
			blend.Factors[2] = 0f;
			blend.Positions[2] = 1f;
			GraphicsPath graphicsPath = new GraphicsPath();
			RectangleF rect = new RectangleF(A_1.Left - 1, A_1.Top - 1, A_1.Width + 2, A_1.Height + 2);
			graphicsPath.AddEllipse(rect);
			PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
			pathGradientBrush.SurroundColors = new Color[1]
			{
				A_3
			};
			pathGradientBrush.Blend = blend;
			pathGradientBrush.CenterColor = A_4;
			PointF pointF = default(PointF);
			pointF.X = (float)(A_1.Width - 2 * A_5) / (float)A_1.Width;
			pointF.Y = (float)(A_1.Height - 2 * A_5) / (float)A_1.Height;
			PointF pointF3 = pathGradientBrush.FocusScales = pointF;
			A_0.FillPath(pathGradientBrush, A_2);
			pathGradientBrush.Dispose();
			graphicsPath.Dispose();
		}

		internal void a(Graphics A_0, Rectangle A_1, GraphicsPath A_2, Color A_3, int A_4, float A_5)
		{
			A_0.TranslateTransform(A_4, A_4);
			PathGradientBrush pathGradientBrush = new PathGradientBrush(A_2);
			Blend blend = new Blend
			{
				Factors = new float[3],
				Positions = new float[3]
			};
			blend.Factors[0] = 0f;
			blend.Positions[0] = 0f;
			blend.Factors[2] = 1f;
			blend.Positions[2] = 1f;
			blend.Factors[1] = A_5;
			blend.Positions[1] = 1f - A_5;
			pathGradientBrush.SurroundColors = new Color[1]
			{
				Color.Transparent
			};
			pathGradientBrush.Blend = blend;
			pathGradientBrush.CenterColor = A_3;
			PointF pointF = default(PointF);
			pointF.X = (float)(A_1.Width - 2 * A_4) / (float)A_1.Width;
			pointF.Y = (float)(A_1.Height - 2 * A_4) / (float)A_1.Height;
			PointF pointF3 = pathGradientBrush.FocusScales = pointF;
			A_0.FillPath(pathGradientBrush, A_2);
			pathGradientBrush.Dispose();
			A_0.ResetTransform();
		}

		internal void a(Graphics A_0, Rectangle A_1, HMIShapeType A_2, GraphicsPath A_3, Color A_4, Color A_5, HMIBkGradientStyle A_6, int A_7, float A_8, int A_9, int A_10, float A_11)
		{
			switch (A_6)
			{
			case HMIBkGradientStyle.BKGS_Shine:
			{
				Blend blend2 = new Blend
				{
					Factors = new float[3],
					Positions = new float[3]
				};
				blend2.Factors[0] = 0f;
				blend2.Positions[0] = 0f;
				blend2.Factors[1] = A_8;
				blend2.Positions[1] = 1f - A_8;
				blend2.Factors[2] = 1f;
				blend2.Positions[2] = 1f;
				double num = Math.PI * (double)A_7 / 180.0;
				GraphicsPath graphicsPath2 = new GraphicsPath();
				Rectangle rectangle = new Rectangle(A_1.Left - 1, A_1.Top - 1, A_1.Width + 2, A_1.Height + 2);
				switch (A_2)
				{
				case HMIShapeType.ST_Ellipse:
					graphicsPath2.AddEllipse(rectangle);
					break;
				default:
					graphicsPath2.AddRectangle(rectangle);
					break;
				case HMIShapeType.ST_Diamond:
				case HMIShapeType.ST_TopTriangle:
				case HMIShapeType.ST_LeftTriangle:
				case HMIShapeType.ST_RightTriangle:
				case HMIShapeType.ST_LeftTopTriangle:
				case HMIShapeType.ST_LeftBottomTriangle:
				case HMIShapeType.ST_RightTopTriangle:
				case HMIShapeType.ST_RightBottomTriangle:
				case HMIShapeType.ST_TopHalfEllipse:
				case HMIShapeType.ST_LeftHalfEllipse:
				case HMIShapeType.ST_RightHalfEllipse:
				case HMIShapeType.ST_LeftTopEllipse:
				case HMIShapeType.ST_LeftBottomEllipse:
				case HMIShapeType.ST_RightTopEllipse:
				case HMIShapeType.ST_RightBottomEllipse:
				case HMIShapeType.ST_LeftTopChord:
				case HMIShapeType.ST_LeftBottomChord:
				case HMIShapeType.ST_RightTopChord:
				case HMIShapeType.ST_RightBottomChord:
				case HMIShapeType.ST_CustomizedChord:
				case HMIShapeType.ST_CustomizedPie:
				case HMIShapeType.ST_Polygon:
				case HMIShapeType.ST_RectLeftTriangle:
				case HMIShapeType.ST_RectRightTriangle:
				case HMIShapeType.ST_RectTopTriangle:
				case HMIShapeType.ST_RectBottomTriangle:
				case HMIShapeType.ST_RectLeftRightTwoTriangle:
				case HMIShapeType.ST_RectTopBottomTwoTriangle:
				case HMIShapeType.ST_RectLRTBFourTriangle:
				case HMIShapeType.ST_RectLeftArc:
				case HMIShapeType.ST_RectRightArc:
				case HMIShapeType.ST_RectTopArc:
				case HMIShapeType.ST_RectBottomArc:
				case HMIShapeType.ST_RectLeftRightTwoArc:
				case HMIShapeType.ST_RectTopBottomTwoArc:
				case HMIShapeType.ST_RectLRTBFourArc:
					graphicsPath2 = (GraphicsPath)A_3.Clone();
					break;
				case HMIShapeType.ST_RoundRectangle:
					a(graphicsPath2, rectangle, A_9);
					break;
				case HMIShapeType.ST_Rectangle:
					graphicsPath2.AddRectangle(rectangle);
					break;
				}
				PathGradientBrush pathGradientBrush2 = new PathGradientBrush(graphicsPath2);
				pathGradientBrush2.SurroundColors = new Color[1]
				{
					A_4
				};
				PointF pointF = default(PointF);
				pointF.X = (float)A_1.Left + (float)A_1.Width / 2f;
				pointF.Y = (float)A_1.Top + (float)A_1.Height / 2f;
				PointF centerPoint = pointF;
				float num3;
				float num2;
				if (Math.Abs(Math.Sin(num)) < 1E-10)
				{
					num2 = 0f;
					num3 = (float)(Math.Cos(num) * (double)A_1.Width / 2.0);
				}
				else if (Math.Abs(Math.Cos(num)) < 1E-10)
				{
					num3 = 0f;
					num2 = (float)(Math.Sin(num) * (double)A_1.Height / 2.0);
				}
				else
				{
					num3 = (float)((double)A_1.Height / (2.0 * Math.Tan(num)));
					num2 = (float)(Math.Tan(num) * (double)A_1.Width / 2.0);
					num3 = ((!(Math.Cos(num) >= 0.0)) ? (0f - Math.Abs(num3)) : Math.Abs(num3));
					num2 = ((!(Math.Sin(num) >= 0.0)) ? (0f - Math.Abs(num2)) : Math.Abs(num2));
					if (num3 < 0f - (float)A_1.Width / 2f)
					{
						num3 = 0f - (float)A_1.Width / 2f;
					}
					else if (num3 > (float)A_1.Width / 2f)
					{
						num3 = (float)A_1.Width / 2f;
					}
					if (num2 >= 0f - (float)A_1.Height / 2f)
					{
						if (num2 > (float)A_1.Height / 2f)
						{
							num2 = (float)A_1.Height / 2f;
						}
					}
					else
					{
						num2 = 0f - (float)A_1.Height / 2f;
					}
				}
				if (A_2 == HMIShapeType.ST_Ellipse)
				{
					num3 = (float)((double)A_1.Width * Math.Cos(num) / 2.0);
					num2 = (float)((double)A_1.Height * Math.Sin(num) / 2.0);
				}
				centerPoint.X += num3 * A_11;
				centerPoint.Y += num2 * A_11;
				pathGradientBrush2.Blend = blend2;
				pathGradientBrush2.CenterPoint = centerPoint;
				pathGradientBrush2.CenterColor = A_5;
				if (A_3 == null)
				{
					if (A_2 == HMIShapeType.ST_Ellipse)
					{
						A_0.FillEllipse(pathGradientBrush2, rectangle);
					}
					else
					{
						A_0.FillRectangle(pathGradientBrush2, A_1);
					}
				}
				else
				{
					A_0.FillPath(pathGradientBrush2, A_3);
				}
				pathGradientBrush2.Dispose();
				break;
			}
			case HMIBkGradientStyle.BKGS_Linear:
			case HMIBkGradientStyle.BKGS_Linear2:
			{
				Blend blend3 = new Blend();
				if (A_6 == HMIBkGradientStyle.BKGS_Linear)
				{
					blend3.Factors = new float[3];
					blend3.Positions = new float[3];
					blend3.Factors[0] = 0f;
					blend3.Positions[0] = 0f;
					blend3.Factors[1] = A_8;
					blend3.Positions[1] = 0.5f * (1f - A_8);
					blend3.Factors[2] = 1f;
					blend3.Positions[2] = 1f;
				}
				else
				{
					blend3.Factors = new float[5];
					blend3.Positions = new float[5];
					blend3.Factors[0] = 0f;
					blend3.Positions[0] = 0f;
					blend3.Factors[1] = A_8;
					blend3.Positions[1] = 0.5f * (1f - A_8);
					blend3.Factors[2] = 1f;
					blend3.Positions[2] = 0.5f;
					blend3.Factors[3] = A_8;
					blend3.Positions[3] = 0.5f + 0.5f * A_8;
					blend3.Factors[4] = 0f;
					blend3.Positions[4] = 1f;
				}
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(A_1.Left - 1, A_1.Top - 1, A_1.Width + 2, A_1.Height + 2), A_4, A_5, A_7)
				{
					Blend = blend3
				};
				if (A_3 != null)
				{
					A_0.FillPath(linearGradientBrush, A_3);
				}
				else
				{
					A_0.FillRectangle(linearGradientBrush, A_1);
				}
				linearGradientBrush.Dispose();
				break;
			}
			case HMIBkGradientStyle.BKGS_Polygon:
			case HMIBkGradientStyle.BKGS_Sphere:
			case HMIBkGradientStyle.BKGS_Sphere2:
			{
				Blend blend = new Blend
				{
					Factors = new float[3],
					Positions = new float[3]
				};
				blend.Factors[0] = 0f;
				blend.Positions[0] = 0f;
				blend.Factors[2] = 1f;
				blend.Positions[2] = 1f;
				blend.Factors[1] = A_8;
				blend.Positions[1] = 1f - A_8;
				GraphicsPath graphicsPath = new GraphicsPath();
				if (A_6 != HMIBkGradientStyle.BKGS_Polygon)
				{
					RectangleF rect = (A_2 == HMIShapeType.ST_Ellipse) ? new RectangleF(A_1.Left - 1, A_1.Top - 1, A_1.Width + 2, A_1.Height + 2) : new RectangleF((float)A_1.Left - 0.415f * (float)A_1.Width / 2f, (float)A_1.Top - 0.415f * (float)A_1.Height / 2f, 1.415f * (float)A_1.Width, 1.415f * (float)A_1.Height);
					graphicsPath.AddEllipse(rect);
				}
				else if (A_2 != HMIShapeType.ST_Polygon && A_2 != HMIShapeType.ST_Diamond && A_2 != HMIShapeType.ST_BottomTriangle && A_2 != HMIShapeType.ST_LeftBottomTriangle && A_2 != HMIShapeType.ST_LeftTopTriangle && A_2 != HMIShapeType.ST_LeftTriangle && A_2 != HMIShapeType.ST_RectBottomTriangle && A_2 != HMIShapeType.ST_RectLeftRightTwoTriangle && A_2 != HMIShapeType.ST_RectLeftTriangle && A_2 != HMIShapeType.ST_RectLRTBFourTriangle && A_2 != HMIShapeType.ST_RectRightTriangle && A_2 != HMIShapeType.ST_RectTopBottomTwoTriangle && A_2 != HMIShapeType.ST_RectTopTriangle && A_2 != HMIShapeType.ST_RightBottomTriangle && A_2 != HMIShapeType.ST_RightTopEllipse && A_2 != HMIShapeType.ST_RightTopTriangle && A_2 != HMIShapeType.ST_RightTriangle && A_2 != HMIShapeType.ST_TopTriangle)
				{
					Point[] points = new Point[4]
					{
						new Point(A_1.Left, A_1.Top),
						new Point(A_1.Left + A_1.Width, A_1.Top),
						new Point(A_1.Left + A_1.Width, A_1.Top + A_1.Height),
						new Point(A_1.Left, A_1.Top + A_1.Height)
					};
					graphicsPath.AddPolygon(points);
				}
				else
				{
					graphicsPath = (GraphicsPath)A_3.Clone();
				}
				PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
				pathGradientBrush.SurroundColors = new Color[1]
				{
					A_4
				};
				pathGradientBrush.Blend = blend;
				pathGradientBrush.CenterColor = A_5;
				if (A_6 == HMIBkGradientStyle.BKGS_Sphere2)
				{
					PointF focusScales = default(PointF);
					if (A_1.Width <= A_1.Height)
					{
						focusScales.X = 0f;
						focusScales.Y = (float)(A_1.Height - A_1.Width) / (float)A_1.Height;
					}
					else
					{
						focusScales.X = (float)(A_1.Width - A_1.Height) / (float)A_1.Width;
						focusScales.Y = 0f;
					}
					pathGradientBrush.FocusScales = focusScales;
				}
				if (A_3 == null)
				{
					A_0.FillRectangle(pathGradientBrush, A_1);
				}
				else
				{
					A_0.FillPath(pathGradientBrush, A_3);
				}
				pathGradientBrush.Dispose();
				break;
			}
			}
		}
	}
}
