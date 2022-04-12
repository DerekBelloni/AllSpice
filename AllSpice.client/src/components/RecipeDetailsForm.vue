<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-4 bg-img rounded elevation-1 p-1 m-1"></div>
      <div class="col-4 rounded elevation-1 bg-secondary">
        <h4>Ingredients</h4>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "@vue/reactivity"
import { AppState } from "../AppState"
export default {
  setup() {
    return {
      backgroundImage: computed(() => `url('${AppState.activeRecipe.picture}')`),
      activeRecipe: computed(() => AppState.activeRecipe)
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
  min-height: 30vw;
  width: 30%;
}
</style>