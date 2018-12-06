import { Category } from "../categories/category.model";

export interface Group {
    groupId: string;
    groupName: string;
    budgeted: number;
    activity: number;
    availability: number;
    categories: Category[];
}