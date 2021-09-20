<template>
  <div class="container mt-3">
    <h1>{{ activeVault.name }}</h1>
    <h4><em>{{ activeVault.description }}</em></h4>
    <p>Keeps: {{ vaultKeeps.length }}</p>
    <div class="row">
      <div class="card-columns">
        <VaultKeepsCard v-for="v in vaultKeeps" :key="v.id" :vaultkeep="v">
        </vaultkeepscard>
      </div>
    </div>
    <KeepDetailsModal v-for="vk in vaultKeeps" :key="vk.id" :vaultkeep="vk" />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import Pop from '../utils/Notifier'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { router } from '../router'
export default {
  setup() {
    const route = useRoute()
    const state = reactive({
      vault: computed(() => AppState.activeVault),
      user: computed(() => AppState.user)
    })
    onMounted(async() => {
      try {
        if (state.vault.CreatorId !== state.user.Id && state.vault.IsPrivate !== false) {
          router.push('Home')
        }
        await vaultsService.getVaultById(route.params.id)
        await vaultsService.getVaultKeeps(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
        // FIXME router push home
      }
    })
    return {
      state,
      vaultKeeps: computed(() => AppState.activeVaultKeeps),
      activeVault: computed(() => AppState.activeVault),
      user: computed(() => AppState.user)
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
