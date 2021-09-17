<template>
  <div class="home flex-grow-1 container-fluid mt-3 px-4">
    <div class="card-columns">
      <KeepsCard v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
    <KeepDetailsModal v-for="k in keeps" :key="k.id" :keep="k" />
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import Pop from '../utils/Notifier'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  setup() {
    onMounted(async() => {
      try {
        await keepsService.getAllKeeps()
      } catch (error) {
        Pop.toast('Something has gone wrong', 'error')
      }
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
