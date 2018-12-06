import { CategoryInformation } from "../categoryInformation/categoryInformation.model";

export interface Category {
    categoryId: number;
    categoryName: number;
    categoryInformation: CategoryInformation;
}