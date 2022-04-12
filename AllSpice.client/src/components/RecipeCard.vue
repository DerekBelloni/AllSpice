<template>
  <div class="row m-2">
    <div
      @click="setActive"
      class="
        col-12
        rounded-top
        elevation-2
        bg-img
        p-2
        d-flex
        flex-column
        justify-content-between
        w-100
        selectable
      "
    >
      <div class="d-flex justify-content-between">
        <div>
          <span class="bg-blur rounded-pill p-1 m-2 fw-bold text-light">
            {{ recipes.category }}
          </span>
        </div>
      </div>
    </div>
    <div
      @click="setActive"
      class="
        p-1
        bg-blur
        text-light
        rounded-bottom
        d-flex
        flex-column
        w-100
        fw-bold
        selectable
      "
    >
      <span>
        {{ recipes.title }}
      </span>
    </div>
  </div>
  <RecipeDetailsModal class="modal" id="recipe-modal">
    <template #modal-body><RecipeDetailsForm /></template>
  </RecipeDetailsModal>
</template>


<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
export default {
  props: {
    recipes:
    {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      backgroundImage: computed(() => `url('${props.recipes.picture}')`),
      setActive() {
        AppState.activeRecipe = props.recipes
        logger.log("[Set to Active Recipe]", props.recipes)
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.bg-img {
  background-image: v-bind(backgroundImage);
  // background-position: center;
  background-size: cover;
  background-position: center;
  min-height: 40vw;
  width: 100%;
}

.bg-blur {
  backdrop-filter: blur(20px);
  background-color: rgb(61, 61, 61);
  opacity: 0.85;
}
</style>