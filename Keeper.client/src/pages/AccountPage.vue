<template>
  <div class="about container-fluid">
    <div class="row">
      <div class="col-md-3 w-100 rounded">
        <img :src="account.picture" alt="profile picture">
      </div>
      <div class="col-md-9">
        <h2>{{ account.name }}</h2>
        <h4>Keeps: 24</h4>
        <h4>Vaults: 5</h4>
      </div>
    </div>
    <div class="row">
      <div class="col">
        Add Vaults
      </div>
    </div>
    <div class="row">
      <div class="col">
        Add Keeps
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Account',
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
