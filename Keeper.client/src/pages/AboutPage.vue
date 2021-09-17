<template>
  <div class="about container mt-3 p-0">
    <div class="row">
      <div class="col-md-3 rounded">
        <img :src="activeProfile.picture" alt="profile picture">
      </div>
      <div class="col-md-9">
        <h2>{{ activeProfile.name }}</h2>
        <h4>Keeps: {{ activeKeeps.length }}</h4>
        <h4>Vaults: {{ activeVaults.length }}</h4>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h1>VAULTS</h1>
      </div>
      <div class="card-columns mt-3">
        <ActiveProfileVaultsCard v-for="v in activeVaults" :key="v.id" :vault="v" />
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h1>KEEPS</h1>
      </div>
      <div class="card-columns mt-3">
        <ActiveProfileKeepsCard v-for="k in activeKeeps" :key="k.id" :keep="k" />
      </div>
    </div>
    <KeepDetailsModal v-for="k in activeKeeps" :key="k.id" :keep="k" />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router'
export default {
  setup() {
    const route = useRoute()
    onMounted(async() => {
      try {
        await profilesService.getProfile(route.params.id)
        await profilesService.getProfileKeeps(route.params.id)
        await profilesService.getProfileVaults(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      activeProfile: computed(() => AppState.activeProfile),
      activeKeeps: computed(() => AppState.activeKeeps),
      activeVaults: computed(() => AppState.activeVaults)
    }
  }
}
</script>

<style scoped>

 </style>
