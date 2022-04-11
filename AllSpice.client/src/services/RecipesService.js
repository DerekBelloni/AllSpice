import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class RecipesService {

  async getRecipes() {
    const res = await api.get('api/recipes')
    logger.log('[recipes retrieved]', res.data)
    AppState.recipes = res.data
  }
  async createRecipe(body) {
    const res = await api.post('api/recipes', body)
    logger.log('[createRecipe]', res.data)
    AppState.myRecipes.push(res.data)
    AppState.recipes.push(res.data)
  }
}

export const recipesService = new RecipesService();