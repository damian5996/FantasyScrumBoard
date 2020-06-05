export interface UserAchievement {
  userId: number;
  achievementId: number;
  earnedDate: Date;
}

export interface Achievement {
  id: number;
  name: string;
  description: string;
  type: number;
}