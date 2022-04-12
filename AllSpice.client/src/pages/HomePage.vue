<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-3">
        <Login />
      </div>
    </div>
    <div class="row justify-content-center m-3">
      <div
        class="
          col-11
          bg-primary
          rounded
          elevation-2
          cover-img
          d-flex
          justify-content-center
          align-items-center
          banner-text
        "
      >
        <h2>All Spice</h2>
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row justify-content-center">
      <div class="col-6 bg-light rounded elevation-2">
        <div class="row">
          <div class="col-4 d-flex justify-content-center selectable">
            <h4>Home</h4>
          </div>
          <div class="col-4 d-flex justify-content-center selectable">
            <h4>My Recipes</h4>
          </div>
          <div class="col-4 d-flex justify-content-center selectable">
            <h4>Favorites</h4>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="container-fluid">
    <div class="row justify-content-around">
      <div
        class="col-12 col-md-3 elevation-2 m-3 selectable rounded"
        data-bs-toggle="modal"
        data-bs-target="#recipe-modal"
        v-for="r in recipes"
        :key="r.id"
      >
        <RecipeCard :recipes="r" />
      </div>
    </div>
  </div>
</template>



<script>
import { computed, onMounted, watchEffect } from "@vue/runtime-core"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { recipesService } from "../services/RecipesService"
import { AppState } from "../AppState"
import { useRoute } from "vue-router"
import Navbar from "../components/Navbar.vue"
export default {
  components: { Navbar },
  setup() {
    const route = useRoute()
    watchEffect(async () => {
      try {
        if (route.name == 'Home') {
          await recipesService.getRecipes()
        }
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    })

    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>



<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
.cover-img {
  background-image: url("https://images.unsplash.com/photo-1540420828642-fca2c5c18abe?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTZ8fGNvb2tpbmd8ZW58MHx8MHx8&auto=format&fit=crop&w=1000&q=60");
  background-size: cover;
  background-position: center;
  min-height: 40vh;
  min-width: 90%;
}

.banner-text {
  color: white;
  font-size: 200px;
  font-family: "Bebas Neue", cursive;
  font-family: "Fredoka One", cursive;
}

.card-border {
  border: black solid 2px;
}
</style>
