<template>
  <header></header>
  <main>
    <router-view />
  </main>
  <footer>
    <div
      class="position-fixed contact-button"
      data-bs-toggle="modal"
      data-bs-target="#create-recipe-modal"
    >
      <i class="mdi mdi-plus contact-button__icon"></i>
    </div>
  </footer>
  <Modal id="create-recipe-modal">
    <template #modal-title>Create a Recipe</template>
    <template #modal-body><CreateRecipeForm /></template>
  </Modal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
body {
  background: #0b0c10;
}

.contact-button {
  background-color: #b5ff7d;
  color: #0b0c10;
  padding: 2em 2em;
  height: 1em;
  width: 1em;
  border-radius: 100%;
  bottom: 1rem;
  right: 1.5rem;
  display: flex;
  justify-content: center;
  align-items: center;
  box-shadow: 0px 0px 0px 2px #0b0c10, 0px 0px 0px 6px #b5ff7d;
}
.contact-button,
.contact-button__icon {
  transition: all 0.5s ease-in-out;
}

.contact-button:hover {
  transform: scale(0.9);
  box-shadow: 0px 0px 0px 2px #0b0c10, 0px 0px 0px 12px #b5ff7d;
  cursor: pointer;
}

.contact-button:hover .contact-button__icon {
  transform: scale(1.5);
}
</style>
