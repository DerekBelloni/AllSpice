<template>
  <form class="d-flex flex-column">
    <label for="">Recipe Title</label>
    <input
      v-model="editable.title"
      type="text"
      placeholder="recipe title..."
      required
    />
    <label for="">Recipe Subtitle</label>
    <input
      v-model="editable.subtitle"
      type="text"
      placeholder="recipe subtitle..."
      required
    />
    <label for="">Recipe Category</label>
    <input
      v-model="editable.category"
      type="text"
      placeholder="recipe category..."
      required
    />
    <label for="">Recipe Picture</label>
    <input
      v-model="editable.picture"
      type="text"
      placeholder="recipe picture..."
      required
    />
    <button
      class="btn btn-primary m-5"
      title="submit form"
      @click="createRecipe"
    >
      Submit
    </button>
  </form>
</template>


<script>
import { Modal } from "bootstrap"
import { ref } from "@vue/reactivity"
import { recipesService } from "../services/RecipesService"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
export default {
  setup() {
    let editable = ref({})
    return {
      editable,
      async createRecipe() {
        try {
          await recipesService.createRecipe(editable.value)
          Modal.getOrCreateInstance(
            document.getElementById("create-recipe-modal")
          ).hide()
          form.reset()
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
</style>